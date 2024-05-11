using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetGraded.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniverisityYearId",
                table: "StudentDetail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UniverisityYearId",
                table: "StudentDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
