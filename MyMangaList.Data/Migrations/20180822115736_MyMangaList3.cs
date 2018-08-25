using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMangaList.Web.Data.Migrations
{
    public partial class MyMangaList3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AspNetUsers_CreatorId1",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_UserId1",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId1",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CreatorId1",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CreatorId1",
                table: "Groups");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Messages",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Groups",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AspNetUsers_CreatorId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CreatorId",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Messages",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "Groups",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorId1",
                table: "Groups",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId1",
                table: "Messages",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CreatorId1",
                table: "Groups",
                column: "CreatorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AspNetUsers_CreatorId1",
                table: "Groups",
                column: "CreatorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_UserId1",
                table: "Messages",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
