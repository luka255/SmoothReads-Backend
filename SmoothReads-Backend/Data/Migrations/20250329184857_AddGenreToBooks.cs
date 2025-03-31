using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmoothReads_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddGenreToBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_books_BookId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_users_UserId",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_favourites_books_BookId",
                table: "favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_favourites_users_UserId",
                table: "favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Reads_books_BookId",
                table: "Reads");

            migrationBuilder.DropForeignKey(
                name: "FK_Reads_users_UserId",
                table: "Reads");

            migrationBuilder.DropForeignKey(
                name: "FK_WantToReads_books_BookId",
                table: "WantToReads");

            migrationBuilder.DropForeignKey(
                name: "FK_WantToReads_users_UserId",
                table: "WantToReads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_favourites",
                table: "favourites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_books",
                table: "books");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "favourites",
                newName: "Favourites");

            migrationBuilder.RenameTable(
                name: "comments",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "books",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_favourites_UserId",
                table: "Favourites",
                newName: "IX_Favourites_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_favourites_BookId",
                table: "Favourites",
                newName: "IX_Favourites_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_comments_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_comments_BookId",
                table: "Comments",
                newName: "IX_Comments_BookId");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favourites",
                table: "Favourites",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Books_BookId",
                table: "Comments",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Books_BookId",
                table: "Favourites",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Users_UserId",
                table: "Favourites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reads_Books_BookId",
                table: "Reads",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reads_Users_UserId",
                table: "Reads",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WantToReads_Books_BookId",
                table: "WantToReads",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WantToReads_Users_UserId",
                table: "WantToReads",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Books_BookId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Books_BookId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Users_UserId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Reads_Books_BookId",
                table: "Reads");

            migrationBuilder.DropForeignKey(
                name: "FK_Reads_Users_UserId",
                table: "Reads");

            migrationBuilder.DropForeignKey(
                name: "FK_WantToReads_Books_BookId",
                table: "WantToReads");

            migrationBuilder.DropForeignKey(
                name: "FK_WantToReads_Users_UserId",
                table: "WantToReads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favourites",
                table: "Favourites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Favourites",
                newName: "favourites");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "comments");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "books");

            migrationBuilder.RenameIndex(
                name: "IX_Favourites_UserId",
                table: "favourites",
                newName: "IX_favourites_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Favourites_BookId",
                table: "favourites",
                newName: "IX_favourites_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "comments",
                newName: "IX_comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BookId",
                table: "comments",
                newName: "IX_comments_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_favourites",
                table: "favourites",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_books",
                table: "books",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_books_BookId",
                table: "comments",
                column: "BookId",
                principalTable: "books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_users_UserId",
                table: "comments",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_favourites_books_BookId",
                table: "favourites",
                column: "BookId",
                principalTable: "books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_favourites_users_UserId",
                table: "favourites",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reads_books_BookId",
                table: "Reads",
                column: "BookId",
                principalTable: "books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reads_users_UserId",
                table: "Reads",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WantToReads_books_BookId",
                table: "WantToReads",
                column: "BookId",
                principalTable: "books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WantToReads_users_UserId",
                table: "WantToReads",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
