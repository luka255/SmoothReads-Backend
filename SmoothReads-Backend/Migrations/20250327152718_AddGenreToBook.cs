using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmoothReads_Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddGenreToBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "Genre",
            table: "Books",
            nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "Genre",
            table: "Books");
        }
    }
}
