using CityInfo.API.Services;

namespace CItyInfo.API.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailTo = "admin@gmail.com";
        private string _mailFrom = "user@gmail.com";

        public void Send(string subject, string message)
        {
            // Send mail - output to debug window
            Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with {nameof(LocalMailService)}.");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}