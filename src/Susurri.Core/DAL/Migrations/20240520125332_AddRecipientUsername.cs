using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Susurri.Core.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipientUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecipientUsername",
                table: "ChatMessages",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipientUsername",
                table: "ChatMessages");
        }
    }
}
