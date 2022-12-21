using Microsoft.EntityFrameworkCore.Migrations;

namespace Drive.Database.Migrations
{
    public partial class QuestionDriveCategoryAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriveCategory",
                table: "Questions",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriveCategory",
                table: "Questions");
        }
    }
}
