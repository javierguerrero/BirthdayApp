using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Birthday", "Email", "LastName", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "baciliogonzales@gmail.com", "Gonzales", "Bacilio", "+51992691213" },
                    { 2, new DateTime(1982, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "javierguerrero.tech@gmail.com", "Guerrero", "Javier", "+51976268172" },
                    { 3, new DateTime(1980, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@gmail.com", "Doe", "John", "+51976268172" }
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
