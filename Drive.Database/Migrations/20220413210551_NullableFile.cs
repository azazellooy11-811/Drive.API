using Microsoft.EntityFrameworkCore.Migrations;

namespace Drive.Database.Migrations
{
    public partial class NullableFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Files_FileId",
                table: "Questions");

            migrationBuilder.AlterColumn<long>(
                name: "FileId",
                table: "Questions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Files_FileId",
                table: "Questions",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Files_FileId",
                table: "Questions");

            migrationBuilder.AlterColumn<long>(
                name: "FileId",
                table: "Questions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Files_FileId",
                table: "Questions",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
