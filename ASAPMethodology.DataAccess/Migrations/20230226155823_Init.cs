using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASAPMethodology.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "ExpenseType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostOfFuture",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CardLastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DocNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyNum = table.Column<int>(type: "int", nullable: false),
                    PolicyBegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstallementNo = table.Column<int>(type: "int", nullable: false),
                    PolicyEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Methodology = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ExpenseTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostOfFuture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostOfFuture_ExpenseType_ExpenseTypeId",
                        column: x => x.ExpenseTypeId,
                        principalSchema: "dbo",
                        principalTable: "ExpenseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CostOfFuture_ExpenseTypeId",
                schema: "dbo",
                table: "CostOfFuture",
                column: "ExpenseTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostOfFuture",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ExpenseType",
                schema: "dbo");
        }
    }
}
