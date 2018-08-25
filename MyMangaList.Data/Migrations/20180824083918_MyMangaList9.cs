using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMangaList.Web.Data.Migrations
{
    public partial class MyMangaList9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friend_AspNetUsers_ContractId",
                table: "Friend");

            migrationBuilder.DropForeignKey(
                name: "FK_Friend_AspNetUsers_UserId",
                table: "Friend");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friend",
                table: "Friend");

            migrationBuilder.RenameTable(
                name: "Friend",
                newName: "Friends");

            migrationBuilder.RenameIndex(
                name: "IX_Friend_UserId",
                table: "Friends",
                newName: "IX_Friends_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Friend_ContractId",
                table: "Friends",
                newName: "IX_Friends_ContractId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_ContractId",
                table: "Friends",
                column: "ContractId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friends_AspNetUsers_UserId",
                table: "Friends",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_ContractId",
                table: "Friends");

            migrationBuilder.DropForeignKey(
                name: "FK_Friends_AspNetUsers_UserId",
                table: "Friends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.RenameTable(
                name: "Friends",
                newName: "Friend");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_UserId",
                table: "Friend",
                newName: "IX_Friend_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Friends_ContractId",
                table: "Friend",
                newName: "IX_Friend_ContractId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friend",
                table: "Friend",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_AspNetUsers_ContractId",
                table: "Friend",
                column: "ContractId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_AspNetUsers_UserId",
                table: "Friend",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
