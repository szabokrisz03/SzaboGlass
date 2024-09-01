using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzaboGlass.Data.Migrations
{
    /// <inheritdoc />
    public partial class GlassAndGlassTypeInitialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlassTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlassTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Glasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    GlassTypeId = table.Column<int>(type: "INTEGER", nullable: true),
                    Date = table.Column<string>(type: "TEXT", nullable: false),
                    PurchasePriceCE = table.Column<int>(type: "INTEGER", nullable: true),
                    PurchasePriceMalyi = table.Column<int>(type: "INTEGER", nullable: true),
                    PriceWithVAT = table.Column<int>(type: "INTEGER", nullable: true),
                    SerialPrice = table.Column<int>(type: "INTEGER", nullable: true),
                    UniquePrice = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Glasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Glasses_GlassTypes_GlassTypeId",
                        column: x => x.GlassTypeId,
                        principalTable: "GlassTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Glasses_GlassTypeId",
                table: "Glasses",
                column: "GlassTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Glasses");

            migrationBuilder.DropTable(
                name: "GlassTypes");
        }
    }
}
