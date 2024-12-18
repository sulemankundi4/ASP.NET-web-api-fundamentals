// WebApplication Builder ko command line arguments ke sath initialize karen
// Ye line application ke configuration aur services ko setup karne ke liye builder object create karti hai
using CityInfo.API;
using CityInfo.API.DBContext;
using CityInfo.API.Services;
using CItyInfo.API.Services;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.Console().WriteTo.File("logs/cityinfo.txt", rollingInterval: RollingInterval.Day).CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Controllers ke liye zaroori services add karen
// Ye line ASP.NET Core MVC controllers ko application mein use karne ke liye services add karti hai
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();

builder.Services.AddProblemDetails();

//builder.Services.AddProblemDetails(options =>
//{
//    options.CustomizeProblemDetails = context =>
//    {
//        context.ProblemDetails.Extensions.Add("additionalInfo", "Additional information about the problem.");
//        context.ProblemDetails.Extensions.Add("server", Environment.MachineName);
//    };
//});

// Endpoints API Explorer service add karen
// Ye line API endpoints ko explore karne ke liye service add karti hai, jo Swagger documentation ke liye zaroori hai
builder.Services.AddEndpointsApiExplorer();

// Swagger generation service add karen
// Ye line Swagger documentation generate karne ke liye service add karti hai, jo API ke endpoints ko document karti hai
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<FileExtensionContentTypeProvider>();
builder.Services.AddSingleton<CitiesDataStore>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//OUR OWN SERVICES
builder.Services.AddTransient<IMailService, LocalMailService>();
builder.Services.AddScoped<ICityInfoRepository, CityInfoRepository>();
builder.Services.AddDbContext<CityInfoContext>(options =>
    options.UseSqlite(builder.Configuration["ConnectionStrings:CityInfoDBConnectionString"]));
///////////////


// Application ko builder ke zariye build karen
// Ye line builder object ke configuration ke sath application ko build karti hai
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

// Agar application development environment mein hai to Swagger aur Swagger UI use karen
// Ye block check karta hai agar application development environment mein hai, to Swagger aur Swagger UI ko enable karta hai
if (app.Environment.IsDevelopment())
{
    // Swagger middleware ko enable karen, jo API documentation ko JSON format mein serve karta hai
    app.UseSwagger();
    // Swagger UI middleware ko enable karen, jo web-based interface provide karta hai API ko explore karne ke liye
    app.UseSwaggerUI();
}

// HTTP requests ko HTTPS par redirect karen
// Ye line HTTP requests ko automatically HTTPS par redirect karti hai, jo security ke liye zaroori hai
app.UseHttpsRedirection();

app.UseRouting();

// Authorization middleware add karen
// Ye line authorization middleware ko add karti hai, jo requests ko authorize karta hai based on user roles ya policies
app.UseAuthorization();

app.UseEndpoints(endPoints =>
{
    // Controllers ke liye endpoints ko map karen
    // Ye line application ke endpoints ko map karti hai, jo controllers ke actions ko handle karte hain
    endPoints.MapControllers();
});

// Application ko run karen
// Ye line application ko run karti hai, jo web server ko start karti hai aur incoming HTTP requests ko listen karti hai
app.Run();