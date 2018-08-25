using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMangaList.Web.Data.Migrations
{
    public partial class MyMangaList6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AspNetUsers_CreatorId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CreatorId",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Groups",
                newName: "Creator");

            migrationBuilder.AlterColumn<string>(
                name: "Creator",
                table: "Groups",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Creator",
                table: "Groups",
                newName: "CreatorId");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Groups",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CreatorId",
                table: "Groups",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AspNetUsers_CreatorId",
                table: "Groups",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
