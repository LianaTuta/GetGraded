using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetGraded.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class addDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeadLine",
                value: new DateTime(2024, 5, 18, 12, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "Id",
                keyValue: 2,
                column: "DeadLine",
                value: new DateTime(2024, 5, 17, 17, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "Id",
                keyValue: 3,
                column: "DeadLine",
                value: new DateTime(2024, 5, 27, 14, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "Id",
                keyValue: 4,
                column: "DeadLine",
                value: new DateTime(2024, 5, 30, 1, 30, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeadLine",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "Id",
                keyValue: 2,
                column: "DeadLine",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "Id",
                keyValue: 3,
                column: "DeadLine",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "Id",
                keyValue: 4,
                column: "DeadLine",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
