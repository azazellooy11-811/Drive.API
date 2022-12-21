using Microsoft.EntityFrameworkCore.Migrations;

namespace Drive.Database.Migrations
{
    public partial class userErrorQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Badges",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ErrorQuestionsId",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Points",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ErrorQuestionsId",
                table: "Users",
                column: "ErrorQuestionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Questions_ErrorQuestionsId",
                table: "Users",
                column: "ErrorQuestionsId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Questions_ErrorQuestionsId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ErrorQuestionsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Badges",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ErrorQuestionsId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Users");
        }
    }
}
