using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmoothReads_Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommentForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "text",
                table: "Comments",
                newName: "Text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Comments",
                newName: "text");
        }
    }
}
