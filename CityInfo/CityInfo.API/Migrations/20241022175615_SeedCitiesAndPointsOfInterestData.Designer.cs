﻿// <auto-generated />
using CityInfo.API.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CityInfo.API.Migrations
{
    [DbContext(typeof(CityInfoContext))]
    [Migration("20241022175615_SeedCitiesAndPointsOfInterestData")]
    partial class SeedCitiesAndPointsOfInterestData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("CityInfo.API.Controllers.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The one with that big park.",
                            Name = "New York City"
                        },
                        new
                        {
                            Id = 2,
                            Description = "The one with the cathedral that was never really finished.",
                            Name = "Antwerp"
                        },
                        new
                        {
                            Id = 3,
                            Description = "The one with that big tower.",
                            Name = "Paris"
                        },
                        new
                        {
                            Id = 4,
                            Description = "The one with the busy crossing.",
                            Name = "Tokyo"
                        },
                        new
                        {
                            Id = 5,
                            Description = "The one with the famous opera house.",
                            Name = "Sydney"
                        },
                        new
                        {
                            Id = 6,
                            Description = "The one with the big clock tower.",
                            Name = "London"
                        },
                        new
                        {
                            Id = 7,
                            Description = "The one with the historic wall.",
                            Name = "Berlin"
                        },
                        new
                        {
                            Id = 8,
                            Description = "The one with the ancient ruins.",
                            Name = "Rome"
                        },
                        new
                        {
                            Id = 9,
                            Description = "The one with the colorful domes.",
                            Name = "Moscow"
                        },
                        new
                        {
                            Id = 10,
                            Description = "The one with the big statue.",
                            Name = "Rio de Janeiro"
                        });
                });

            modelBuilder.Entity("CityInfo.API.Controllers.Entities.PointOfInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PointOfInterests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            Name = "Central Park"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            Name = "Empire State Building"
                        },
                        new
                        {
                            Id = 3,
                            CityId = 1,
                            Name = "Statue of Liberty"
                        },
                        new
                        {
                            Id = 4,
                            CityId = 2,
                            Name = "Cathedral of Our Lady"
                        },
                        new
                        {
                            Id = 5,
                            CityId = 2,
                            Name = "Antwerp Central Station"
                        },
                        new
                        {
                            Id = 6,
                            CityId = 3,
                            Name = "Tokyo Tower"
                        },
                        new
                        {
                            Id = 7,
                            CityId = 3,
                            Name = "Meiji Shrine"
                        },
                        new
                        {
                            Id = 8,
                            CityId = 5,
                            Name = "Sydney Opera House"
                        },
                        new
                        {
                            Id = 9,
                            CityId = 5,
                            Name = "Sydney Harbour Bridge"
                        },
                        new
                        {
                            Id = 10,
                            CityId = 6,
                            Name = "Big Ben"
                        },
                        new
                        {
                            Id = 11,
                            CityId = 6,
                            Name = "British Museum"
                        },
                        new
                        {
                            Id = 12,
                            CityId = 7,
                            Name = "The Berlin Wall"
                        },
                        new
                        {
                            Id = 13,
                            CityId = 7,
                            Name = "The Brandenburg Gate"
                        },
                        new
                        {
                            Id = 14,
                            CityId = 8,
                            Name = "The Colosseum"
                        },
                        new
                        {
                            Id = 15,
                            CityId = 8,
                            Name = "The Pantheon"
                        },
                        new
                        {
                            Id = 16,
                            CityId = 9,
                            Name = "St. Basil's Cathedral"
                        },
                        new
                        {
                            Id = 17,
                            CityId = 9,
                            Name = "The Kremlin"
                        },
                        new
                        {
                            Id = 18,
                            CityId = 10,
                            Name = "Christ the Redeemer"
                        },
                        new
                        {
                            Id = 19,
                            CityId = 10,
                            Name = "Sugarloaf Mountain"
                        });
                });

            modelBuilder.Entity("CityInfo.API.Controllers.Entities.PointOfInterest", b =>
                {
                    b.HasOne("CityInfo.API.Controllers.Entities.City", "City")
                        .WithMany("PointOfInterest")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CityInfo.API.Controllers.Entities.City", b =>
                {
                    b.Navigation("PointOfInterest");
                });
#pragma warning restore 612, 618
        }
    }
}
