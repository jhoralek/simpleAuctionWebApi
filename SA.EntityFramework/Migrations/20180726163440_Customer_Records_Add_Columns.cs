using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SA.EntityFramework.Migrations
{
    public partial class Customer_Records_Add_Columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Place",
                schema: "sa-ef-core",
                table: "Records",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                schema: "sa-ef-core",
                table: "Customers",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "sa-ef-core",
                table: "Countries",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Place",
                schema: "sa-ef-core",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                schema: "sa-ef-core",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                schema: "sa-ef-core",
                table: "Countries",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
