using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMangaList.Web.Data.Migrations
{
    public partial class MyMangaList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Manga_MangaId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Group_AspNetUsers_CreatorId1",
                table: "Group");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Group_GroupId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_UserId1",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInGroups_Group_GroupId",
                table: "UsersInGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInGroups_AspNetUsers_UserId",
                table: "UsersInGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInGroups",
                table: "UsersInGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Group",
                table: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "UsersInGroups",
                newName: "UsersInGrouos");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "Group",
                newName: "Groups");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInGroups_GroupId",
                table: "UsersInGrouos",
                newName: "IX_UsersInGrouos_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_UserId1",
                table: "Messages",
                newName: "IX_Messages_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Message_GroupId",
                table: "Messages",
                newName: "IX_Messages_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Group_CreatorId1",
                table: "Groups",
                newName: "IX_Groups_CreatorId1");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_MangaId",
                table: "Comments",
                newName: "IX_Comments_MangaId");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Manga",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Manga",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Manga",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersInGrouos",
                table: "UsersInGrouos",
                columns: new[] { "UserId", "GroupId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Groups",
                table: "Groups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Manga_MangaId",
                table: "Comments",
                column: "MangaId",
                principalTable: "Manga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AspNetUsers_CreatorId1",
                table: "Groups",
                column: "CreatorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Groups_GroupId",
                table: "Messages",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_UserId1",
                table: "Messages",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInGrouos_Groups_GroupId",
                table: "UsersInGrouos",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInGrouos_AspNetUsers_UserId",
                table: "UsersInGrouos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Manga_MangaId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AspNetUsers_CreatorId1",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Groups_GroupId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_UserId1",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInGrouos_Groups_GroupId",
                table: "UsersInGrouos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInGrouos_AspNetUsers_UserId",
                table: "UsersInGrouos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInGrouos",
                table: "UsersInGrouos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Groups",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Manga");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Manga");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Manga");

            migrationBuilder.RenameTable(
                name: "UsersInGrouos",
                newName: "UsersInGroups");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "Groups",
                newName: "Group");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_UsersInGrouos_GroupId",
                table: "UsersInGroups",
                newName: "IX_UsersInGroups_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_UserId1",
                table: "Message",
                newName: "IX_Message_UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_GroupId",
                table: "Message",
                newName: "IX_Message_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Groups_CreatorId1",
                table: "Group",
                newName: "IX_Group_CreatorId1");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comment",
                newName: "IX_Comment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_MangaId",
                table: "Comment",
                newName: "IX_Comment_MangaId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersInGroups",
                table: "UsersInGroups",
                columns: new[] { "UserId", "GroupId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Group",
                table: "Group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Manga_MangaId",
                table: "Comment",
                column: "MangaId",
                principalTable: "Manga",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Group_AspNetUsers_CreatorId1",
                table: "Group",
                column: "CreatorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Group_GroupId",
                table: "Message",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_UserId1",
                table: "Message",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInGroups_Group_GroupId",
                table: "UsersInGroups",
                column: "GroupId",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInGroups_AspNetUsers_UserId",
                table: "UsersInGroups",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
