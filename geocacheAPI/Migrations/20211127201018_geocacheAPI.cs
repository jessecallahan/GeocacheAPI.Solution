using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace geocacheAPI.Migrations
{
    public partial class geocacheAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Geocaches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Lat = table.Column<double>(nullable: false),
                    Lng = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geocaches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    GeocacheId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Geocaches_GeocacheId",
                        column: x => x.GeocacheId,
                        principalTable: "Geocaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Geocaches",
                columns: new[] { "Id", "Lat", "Lng", "Name" },
                values: new object[] { 1, 47.606200000000001, 122.3321, "Treasure Island" });

            migrationBuilder.InsertData(
                table: "Geocaches",
                columns: new[] { "Id", "Lat", "Lng", "Name" },
                values: new object[] { 2, 47.606200000000001, 122.3321, "Magic Mountain" });

            migrationBuilder.InsertData(
                table: "Geocaches",
                columns: new[] { "Id", "Lat", "Lng", "Name" },
                values: new object[] { 3, 47.606200000000001, 122.3321, "Discovery Park" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "EndDate", "GeocacheId", "IsActive", "Name", "StartDate" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, "Coins", new DateTime(2021, 11, 27, 12, 10, 16, 226, DateTimeKind.Local).AddTicks(3960) });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "EndDate", "GeocacheId", "IsActive", "Name", "StartDate" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, "Jewelry", new DateTime(2021, 11, 27, 12, 10, 16, 393, DateTimeKind.Local).AddTicks(2320) });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "EndDate", "GeocacheId", "IsActive", "Name", "StartDate" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, "Trading Stones", new DateTime(2021, 11, 27, 12, 10, 16, 393, DateTimeKind.Local).AddTicks(2400) });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "EndDate", "GeocacheId", "IsActive", "Name", "StartDate" },
                values: new object[] { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, "Compass", new DateTime(2021, 11, 27, 12, 10, 16, 393, DateTimeKind.Local).AddTicks(2410) });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "EndDate", "GeocacheId", "IsActive", "Name", "StartDate" },
                values: new object[] { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, "Poem", new DateTime(2021, 11, 27, 12, 10, 16, 393, DateTimeKind.Local).AddTicks(2410) });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "EndDate", "GeocacheId", "IsActive", "Name", "StartDate" },
                values: new object[] { 6, new DateTime(2021, 11, 27, 12, 10, 16, 393, DateTimeKind.Local).AddTicks(2420), 3, false, "Stamps", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Items_GeocacheId",
                table: "Items",
                column: "GeocacheId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Geocaches");
        }
    }
}
