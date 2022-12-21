using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Drive.Database.Migrations
{
    public partial class neznayuctho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BadgesName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Badges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiderBoard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Points = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiderBoard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiderBoard_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserErrorQuestions",
                columns: table => new
                {
                    ErrorQuestionId = table.Column<long>(type: "bigint", nullable: false),
                    ErrorUsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserErrorQuestions", x => new { x.ErrorQuestionId, x.ErrorUsersId });
                    table.ForeignKey(
                        name: "FK_UserErrorQuestions_Questions_ErrorQuestionId",
                        column: x => x.ErrorQuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserErrorQuestions_Users_ErrorUsersId",
                        column: x => x.ErrorUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBadgesTable",
                columns: table => new
                {
                    BadgesId = table.Column<int>(type: "integer", nullable: false),
                    BadgesUsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBadgesTable", x => new { x.BadgesId, x.BadgesUsersId });
                    table.ForeignKey(
                        name: "FK_UserBadgesTable_Badges_BadgesId",
                        column: x => x.BadgesId,
                        principalTable: "Badges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBadgesTable_Users_BadgesUsersId",
                        column: x => x.BadgesUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiderBoard_UserId",
                table: "LiderBoard",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBadgesTable_BadgesUsersId",
                table: "UserBadgesTable",
                column: "BadgesUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserErrorQuestions_ErrorUsersId",
                table: "UserErrorQuestions",
                column: "ErrorUsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiderBoard");

            migrationBuilder.DropTable(
                name: "UserBadgesTable");

            migrationBuilder.DropTable(
                name: "UserErrorQuestions");

            migrationBuilder.DropTable(
                name: "Badges");

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
    }
}
