using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzaboGlass.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMultiplierToGlass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Multiplier",
                table: "Glasses",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Multiplier",
                table: "Glasses");
        }
    }
}
