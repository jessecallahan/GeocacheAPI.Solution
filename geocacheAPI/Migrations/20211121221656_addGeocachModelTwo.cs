using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace geocacheAPI.Migrations
{
    public partial class addGeocachModelTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Geocaches",
                columns: table => new
                {
                    GeocacheId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Coordinate = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geocaches", x => x.GeocacheId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_GeocacheId",
                table: "Items",
                column: "GeocacheId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Geocaches_GeocacheId",
                table: "Items",
                column: "GeocacheId",
                principalTable: "Geocaches",
                principalColumn: "GeocacheId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Geocaches_GeocacheId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Geocaches");

            migrationBuilder.DropIndex(
                name: "IX_Items_GeocacheId",
                table: "Items");
        }
    }
}
