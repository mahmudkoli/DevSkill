using Microsoft.EntityFrameworkCore.Migrations;

namespace DevSkill.Web.Migrations
{
    public partial class StudentRegEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentRegistrations",
                table: "StudentRegistrations");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentRegistrations",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentRegistrations",
                table: "StudentRegistrations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrations_StudentId",
                table: "StudentRegistrations",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentRegistrations",
                table: "StudentRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_StudentRegistrations_StudentId",
                table: "StudentRegistrations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentRegistrations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentRegistrations",
                table: "StudentRegistrations",
                columns: new[] { "StudentId", "CourseId" });
        }
    }
}
