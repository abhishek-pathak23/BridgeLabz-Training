using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactsApiEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Category", "CreatedAt", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Work", new DateTime(2026, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc), "abhi@example.com", "Abhishek", "Pathak", "1234567890" },
                    { 2, "Personal", new DateTime(2026, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc), "ananya@example.com", "Ananya", "Sharma", "0987654321" },
                    { 3, "Work", new DateTime(2026, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc), "rahul@example.com", "Rahul", "Verma", "1122334455" },
                    { 4, "Personal", new DateTime(2026, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc), "priya@example.com", "Priya", "Patel", "5544332211" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
