using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GetGraded.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserLoginId = table.Column<int>(type: "int", nullable: false),
                    UniverisityYearId = table.Column<int>(type: "int", nullable: false),
                    UniversityYearId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentDetail_UniversityYear_UniversityYearId",
                        column: x => x.UniversityYearId,
                        principalTable: "UniversityYear",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentDetail_UserLoginDetails_UserLoginId",
                        column: x => x.UserLoginId,
                        principalTable: "UserLoginDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetail_UniversityYearId",
                table: "StudentDetail",
                column: "UniversityYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetail_UserLoginId",
                table: "StudentDetail",
                column: "UserLoginId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentDetail");
        }
    }
}
