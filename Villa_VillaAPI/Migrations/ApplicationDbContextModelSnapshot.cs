﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Villa_VillaAPI.Data;

#nullable disable

namespace Villa_VillaAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Villa_VillaAPI.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Meter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Occupancy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "",
                            CreateDate = new DateTime(2023, 8, 27, 3, 8, 0, 691, DateTimeKind.Local).AddTicks(8071),
                            Details = "Some dummy text",
                            ImageUrl = "https://www.raffles.com/assets/0/72/2764/2765/2786/6c64d74a-f58d-4de2-a61e-8666413a354c.jpg",
                            Meter = "550",
                            Name = "Royal",
                            Occupancy = "5",
                            Rate = "220",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "",
                            CreateDate = new DateTime(2023, 8, 27, 3, 8, 0, 691, DateTimeKind.Local).AddTicks(8125),
                            Details = "Some dummy text",
                            ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/301483778.jpg?k=b1f449beb857de98e8287c34956b672956926c2d03ac185ff8d9a348622c157a&o=&hp=1",
                            Meter = "450",
                            Name = "Swimpoll",
                            Occupancy = "6",
                            Rate = "200",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "",
                            CreateDate = new DateTime(2023, 8, 27, 3, 8, 0, 691, DateTimeKind.Local).AddTicks(8127),
                            Details = "Some dummy text",
                            ImageUrl = "https://media.vrbo.com/lodging/30000000/29490000/29484300/29484212/b479b134.c10.jpg",
                            Meter = "450",
                            Name = "partyVilla",
                            Occupancy = "6",
                            Rate = "200",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
