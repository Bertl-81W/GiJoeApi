using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GiJoeApi.Migrations
{
    /// <inheritdoc />
    public partial class AddFactionToCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Faction",
                table: "Characters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Faction",
                table: "Characters");
        }
    }
}
