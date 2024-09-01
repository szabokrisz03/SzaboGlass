using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzaboGlass.Data.Migrations
{
    /// <inheritdoc />
    public partial class GlassRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceWithVAT",
                table: "Glasses");

            migrationBuilder.DropColumn(
                name: "SerialPrice",
                table: "Glasses");

            migrationBuilder.DropColumn(
                name: "UniquePrice",
                table: "Glasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Glasses_GlassTypes_GlassTypeId",
                table: "Glasses");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Glasses");

            migrationBuilder.AlterColumn<int>(
                name: "GlassTypeId",
                table: "Glasses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Glasses_GlassTypes_GlassTypeId",
                table: "Glasses",
                column: "GlassTypeId",
                principalTable: "GlassTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Glasses_GlassTypes_GlassTypeId",
                table: "Glasses");

            migrationBuilder.AlterColumn<int>(
                name: "GlassTypeId",
                table: "Glasses",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Glasses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Glasses_GlassTypes_GlassTypeId",
                table: "Glasses",
                column: "GlassTypeId",
                principalTable: "GlassTypes",
                principalColumn: "Id");

            migrationBuilder.AddColumn<int>(
                name: "PriceWithVAT",
                table: "Glasses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SerialPrice",
                table: "Glasses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UniquePrice",
                table: "Glasses",
                type: "INTEGER",
                nullable: true);
        }
    }
}
