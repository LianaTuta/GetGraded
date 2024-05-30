using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetGraded.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "Id",
                keyValue: 2,
                column: "UniversityYearId",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assignment",
                keyColumn: "Id",
                keyValue: 2,
                column: "UniversityYearId",
                value: 2);
        }
    }
}
