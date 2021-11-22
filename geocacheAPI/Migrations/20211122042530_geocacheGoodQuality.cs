using Microsoft.EntityFrameworkCore.Migrations;

namespace geocacheAPI.Migrations
{
    public partial class geocacheGoodQuality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Items",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GeocacheId",
                table: "Geocaches",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Items",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Geocaches",
                newName: "GeocacheId");
        }
    }
}
