using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Forum.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forum", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Forum",
                columns: new[] { "Id", "CreatedDate", "Description", "State", "Status", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 3, 0, 40, 37, 383, DateTimeKind.Local).AddTicks(3113), " ტესტ საკითხი 111111111", 0, 1, "ტესტი1" },
                    { 2, new DateTime(2024, 6, 3, 0, 40, 37, 383, DateTimeKind.Local).AddTicks(3126), " ტესტ საკითხი 222222", 0, 1, "ტესტი2" },
                    { 3, new DateTime(2024, 6, 3, 0, 40, 37, 383, DateTimeKind.Local).AddTicks(3127), " ტესტ საკითხი 333333", 0, 1, "ტესტი2" },
                    { 4, new DateTime(2024, 6, 3, 0, 40, 37, 383, DateTimeKind.Local).AddTicks(3128), " ტესტ საკითხი 444444", 0, 1, "ტესტი4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forum");
        }
    }
}
