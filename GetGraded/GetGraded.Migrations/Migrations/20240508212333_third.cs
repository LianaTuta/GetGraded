using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GetGraded.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniversityYear",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityYear", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Department 2");

            migrationBuilder.InsertData(
                table: "UniversityYear",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "1st year" },
                    { 2, "2nd year" },
                    { 3, "3rd year" },
                    { 4, "4th year" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniversityYear");

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Department 1");
        }
    }
}
