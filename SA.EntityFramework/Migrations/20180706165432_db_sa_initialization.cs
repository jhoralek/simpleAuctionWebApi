using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SA.EntityFramework.Migrations
{
    public partial class db_sa_initialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sa-ef-core");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "sa-ef-core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Created = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                schema: "sa-ef-core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    City = table.Column<string>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    PostCode = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "sa-ef-core",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "sa-ef-core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AddressId = table.Column<int>(nullable: false),
                    BirthNumber = table.Column<string>(nullable: true),
                    CompanyLegalNumer = table.Column<string>(nullable: true),
                    CompanyNumber = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    FeeExspiration = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    IsDealer = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    TitleAfter = table.Column<string>(nullable: true),
                    TitleBefore = table.Column<string>(nullable: true),
                    WebPageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "sa-ef-core",
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "sa-ef-core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Created = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsAgreeementToTerms = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(maxLength: 2, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    SendingNews = table.Column<bool>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "sa-ef-core",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                schema: "sa-ef-core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Axle = table.Column<string>(maxLength: 45, nullable: true),
                    Body = table.Column<string>(maxLength: 100, nullable: true),
                    Colors = table.Column<string>(maxLength: 200, nullable: true),
                    ContactToAppointment = table.Column<string>(maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    DateOfFirstRegistration = table.Column<DateTime>(nullable: true),
                    Defects = table.Column<string>(nullable: true),
                    Dimensions = table.Column<string>(maxLength: 250, nullable: true),
                    Doors = table.Column<int>(nullable: true),
                    EngineCapacity = table.Column<string>(maxLength: 45, nullable: true),
                    Equipment = table.Column<string>(maxLength: 250, nullable: true),
                    EuroNorm = table.Column<string>(maxLength: 10, nullable: true),
                    Fuel = table.Column<string>(maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    MaximumWeight = table.Column<string>(maxLength: 100, nullable: true),
                    MaximumWeightOfRide = table.Column<string>(maxLength: 100, nullable: true),
                    Mileage = table.Column<string>(maxLength: 50, nullable: true),
                    MinimumBid = table.Column<decimal>(nullable: false),
                    MoreDescription = table.Column<string>(nullable: true),
                    MostTechnicallyAcceptableWeight = table.Column<string>(maxLength: 250, nullable: true),
                    MostTechnicallyWeightOfRide = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(nullable: false),
                    NumberOfSeets = table.Column<int>(nullable: true),
                    OperationWeight = table.Column<string>(maxLength: 250, nullable: true),
                    Power = table.Column<string>(maxLength: 45, nullable: true),
                    RegistrationCheck = table.Column<string>(maxLength: 100, nullable: true),
                    StartingPrice = table.Column<decimal>(nullable: false),
                    State = table.Column<string>(maxLength: 100, nullable: true),
                    Stk = table.Column<DateTime>(nullable: true),
                    Transmission = table.Column<string>(maxLength: 45, nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    ValidFrom = table.Column<DateTime>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    Vin = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Records_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "sa-ef-core",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "sa-ef-core",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                schema: "sa-ef-core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Created = table.Column<DateTime>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    RecordId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_Records_RecordId",
                        column: x => x.RecordId,
                        principalSchema: "sa-ef-core",
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "sa-ef-core",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "sa-ef-core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Created = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Path = table.Column<string>(nullable: false),
                    RecordId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Records_RecordId",
                        column: x => x.RecordId,
                        principalSchema: "sa-ef-core",
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Files_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "sa-ef-core",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                schema: "sa-ef-core",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_RecordId",
                schema: "sa-ef-core",
                table: "Bids",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_UserId",
                schema: "sa-ef-core",
                table: "Bids",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                schema: "sa-ef-core",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_RecordId",
                schema: "sa-ef-core",
                table: "Files",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserId",
                schema: "sa-ef-core",
                table: "Files",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_CustomerId",
                schema: "sa-ef-core",
                table: "Records",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_UserId",
                schema: "sa-ef-core",
                table: "Records",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CustomerId",
                schema: "sa-ef-core",
                table: "Users",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bids",
                schema: "sa-ef-core");

            migrationBuilder.DropTable(
                name: "Files",
                schema: "sa-ef-core");

            migrationBuilder.DropTable(
                name: "Records",
                schema: "sa-ef-core");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "sa-ef-core");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "sa-ef-core");

            migrationBuilder.DropTable(
                name: "Addresses",
                schema: "sa-ef-core");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "sa-ef-core");
        }
    }
}
