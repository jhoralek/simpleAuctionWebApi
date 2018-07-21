﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Storage.Internal;
using SA.EntityFramework.EntityFramework;
using System;

namespace SA.EntityFramework.Migrations
{
    [DbContext(typeof(SaDbContext))]
    [Migration("20180721124532_Alter_Countries_Add_Column_Language")]
    partial class Alter_Countries_Add_Column_Language
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("sa-ef-core")
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("SA.Core.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<int>("CountryId");

                    b.Property<DateTime?>("Created");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Addresses");

                    b.HasAnnotation("MySQL:Collation", "utf8_general_ci");

                    b.HasAnnotation("MySQL:Charset", "utf8");
                });

            modelBuilder.Entity("SA.Core.Model.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Created");

                    b.Property<decimal>("Price");

                    b.Property<int>("RecordId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RecordId");

                    b.HasIndex("UserId");

                    b.ToTable("Bids");

                    b.HasAnnotation("MySQL:Collation", "utf8_general_ci");

                    b.HasAnnotation("MySQL:Charset", "utf8");
                });

            modelBuilder.Entity("SA.Core.Model.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Created");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasAnnotation("MySQL:Collation", "utf8_general_ci");

                    b.HasAnnotation("MySQL:Charset", "utf8");
                });

            modelBuilder.Entity("SA.Core.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<string>("BirthNumber")
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("CompanyLegalNumer")
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("CompanyNumber")
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<DateTime?>("Created");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<DateTime?>("FeeExspiration");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<bool>("IsDealer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("TitleAfter")
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("TitleBefore")
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("WebPageUrl")
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Customers");

                    b.HasAnnotation("MySQL:Collation", "utf8_general_ci");

                    b.HasAnnotation("MySQL:Charset", "utf8");
                });

            modelBuilder.Entity("SA.Core.Model.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Created");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<int>("RecordId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RecordId");

                    b.HasIndex("UserId");

                    b.ToTable("Files");

                    b.HasAnnotation("MySQL:Collation", "utf8_general_ci");

                    b.HasAnnotation("MySQL:Charset", "utf8");
                });

            modelBuilder.Entity("SA.Core.Model.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Axle")
                        .HasMaxLength(45)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("Body")
                        .HasMaxLength(100)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("Colors")
                        .HasMaxLength(200)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("ContactToAppointment")
                        .HasMaxLength(100)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<DateTime?>("Created");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime?>("DateOfFirstRegistration");

                    b.Property<string>("Defects")
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("Dimensions")
                        .HasMaxLength(250)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<int?>("Doors");

                    b.Property<string>("EngineCapacity")
                        .HasMaxLength(45)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("Equipment")
                        .HasMaxLength(250)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("EuroNorm")
                        .HasMaxLength(10)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("Fuel")
                        .HasMaxLength(10)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<bool>("IsActive");

                    b.Property<string>("MaximumWeight")
                        .HasMaxLength(100)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("MaximumWeightOfRide")
                        .HasMaxLength(100)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("Mileage")
                        .HasMaxLength(50)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<decimal>("MinimumBid");

                    b.Property<string>("MoreDescription")
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("MostTechnicallyAcceptableWeight")
                        .HasMaxLength(250)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("MostTechnicallyWeightOfRide")
                        .HasMaxLength(100)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<int?>("NumberOfSeets");

                    b.Property<string>("OperationWeight")
                        .HasMaxLength(250)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("Power")
                        .HasMaxLength(45)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("RegistrationCheck")
                        .HasMaxLength(100)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<decimal>("StartingPrice");

                    b.Property<string>("State")
                        .HasMaxLength(100)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<DateTime?>("Stk");

                    b.Property<string>("Transmission")
                        .HasMaxLength(45)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.Property<string>("Vin")
                        .HasMaxLength(45)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("UserId");

                    b.ToTable("Records");

                    b.HasAnnotation("MySQL:Collation", "utf8_general_ci");

                    b.HasAnnotation("MySQL:Charset", "utf8");
                });

            modelBuilder.Entity("SA.Core.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Created");

                    b.Property<int>("CustomerId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsAgreeementToTerms");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<bool>("SendingNews");

                    b.Property<string>("Token")
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasAnnotation("MySQL:Collation", "utf8_general_ci")
                        .HasAnnotation("MySQL:Charset", "utf8");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Users");

                    b.HasAnnotation("MySQL:Collation", "utf8_general_ci");

                    b.HasAnnotation("MySQL:Charset", "utf8");
                });

            modelBuilder.Entity("SA.Core.Model.Address", b =>
                {
                    b.HasOne("SA.Core.Model.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SA.Core.Model.Bid", b =>
                {
                    b.HasOne("SA.Core.Model.Record", "Record")
                        .WithMany()
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SA.Core.Model.User", "User")
                        .WithMany("Bids")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SA.Core.Model.Customer", b =>
                {
                    b.HasOne("SA.Core.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SA.Core.Model.File", b =>
                {
                    b.HasOne("SA.Core.Model.Record", "Record")
                        .WithMany("Files")
                        .HasForeignKey("RecordId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SA.Core.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SA.Core.Model.Record", b =>
                {
                    b.HasOne("SA.Core.Model.Customer", "Customer")
                        .WithMany("Records")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SA.Core.Model.User", "User")
                        .WithMany("Records")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SA.Core.Model.User", b =>
                {
                    b.HasOne("SA.Core.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}