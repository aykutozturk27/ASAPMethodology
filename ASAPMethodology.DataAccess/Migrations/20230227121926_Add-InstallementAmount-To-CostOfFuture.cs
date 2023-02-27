using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASAPMethodology.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddInstallementAmountToCostOfFuture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: new Guid("148054bc-8d82-4fbb-b54e-c6f6457260e3"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: new Guid("555a09cf-9a36-42e5-8c7a-29b521e4336c"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: new Guid("9ee9d6dd-c409-436b-9e30-171826b3b565"));

            migrationBuilder.AlterColumn<string>(
                name: "Methodology",
                schema: "dbo",
                table: "CostOfFuture",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "CardName",
                schema: "dbo",
                table: "CostOfFuture",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "CardLastName",
                schema: "dbo",
                table: "CostOfFuture",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<decimal>(
                name: "InstallementAmount",
                schema: "dbo",
                table: "CostOfFuture",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ExpenseType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3c594c8a-fa4d-4292-bdeb-8d71d760c2f6"), "Kira" },
                    { new Guid("d3635a4d-a726-4e1a-900e-b58b724f1996"), "Sigorta" },
                    { new Guid("fa0709bb-779f-4ba4-aa09-ea95d2a677b5"), "Kasko" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: new Guid("3c594c8a-fa4d-4292-bdeb-8d71d760c2f6"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: new Guid("d3635a4d-a726-4e1a-900e-b58b724f1996"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "ExpenseType",
                keyColumn: "Id",
                keyValue: new Guid("fa0709bb-779f-4ba4-aa09-ea95d2a677b5"));

            migrationBuilder.DropColumn(
                name: "InstallementAmount",
                schema: "dbo",
                table: "CostOfFuture");

            migrationBuilder.AlterColumn<string>(
                name: "Methodology",
                schema: "dbo",
                table: "CostOfFuture",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardName",
                schema: "dbo",
                table: "CostOfFuture",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardLastName",
                schema: "dbo",
                table: "CostOfFuture",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "ExpenseType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("148054bc-8d82-4fbb-b54e-c6f6457260e3"), "Kira" },
                    { new Guid("555a09cf-9a36-42e5-8c7a-29b521e4336c"), "Sigorta" },
                    { new Guid("9ee9d6dd-c409-436b-9e30-171826b3b565"), "Kasko" }
                });
        }
    }
}
