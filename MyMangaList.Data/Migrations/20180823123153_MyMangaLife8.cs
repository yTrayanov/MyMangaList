using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMangaList.Web.Data.Migrations
{
    public partial class MyMangaLife8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserManga_Manga_MangaId",
                table: "UserManga");

            migrationBuilder.DropForeignKey(
                name: "FK_UserManga_AspNetUsers_UserId",
                table: "UserManga");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserManga",
                table: "UserManga");

            migrationBuilder.RenameTable(
                name: "UserManga",
                newName: "UsersManga");

            migrationBuilder.RenameIndex(
                name: "IX_UserManga_UserId",
                table: "UsersManga",
                newName: "IX_UsersManga_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserManga_MangaId",
                table: "UsersManga",
                newName: "IX_UsersManga_MangaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersManga",
                table: "UsersManga",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersManga_Manga_MangaId",
                table: "UsersManga",
                column: "MangaId",
                principalTable: "Manga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersManga_AspNetUsers_UserId",
                table: "UsersManga",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersManga_Manga_MangaId",
                table: "UsersManga");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersManga_AspNetUsers_UserId",
                table: "UsersManga");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersManga",
                table: "UsersManga");

            migrationBuilder.RenameTable(
                name: "UsersManga",
                newName: "UserManga");

            migrationBuilder.RenameIndex(
                name: "IX_UsersManga_UserId",
                table: "UserManga",
                newName: "IX_UserManga_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersManga_MangaId",
                table: "UserManga",
                newName: "IX_UserManga_MangaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserManga",
                table: "UserManga",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserManga_Manga_MangaId",
                table: "UserManga",
                column: "MangaId",
                principalTable: "Manga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserManga_AspNetUsers_UserId",
                table: "UserManga",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
