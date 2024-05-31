using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Forum",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 16, 22, 3, 870, DateTimeKind.Local).AddTicks(1483));

            migrationBuilder.UpdateData(
                table: "Forum",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 16, 22, 3, 870, DateTimeKind.Local).AddTicks(1496));

            migrationBuilder.UpdateData(
                table: "Forum",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 16, 22, 3, 870, DateTimeKind.Local).AddTicks(1497));

            migrationBuilder.UpdateData(
                table: "Forum",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 16, 22, 3, 870, DateTimeKind.Local).AddTicks(1499));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Forum",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 16, 19, 40, 110, DateTimeKind.Local).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "Forum",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 16, 19, 40, 110, DateTimeKind.Local).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "Forum",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 16, 19, 40, 110, DateTimeKind.Local).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "Forum",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 31, 16, 19, 40, 110, DateTimeKind.Local).AddTicks(2196));
        }
    }
}
