using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NudeApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "HighValueItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighValueItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HighValueItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("1ab2eb38-22b0-4643-9730-402b6e68c2e9"), "None" },
                    { new Guid("bdf8686d-0fac-466e-9ac8-9bb73dc9db60"), "Electronics" },
                    { new Guid("4d0e5558-b897-4b8e-8754-9f4899719923"), "Clothing" },
                    { new Guid("3daf2519-2dd0-47d7-9bdb-cb5f7c1b1b34"), "Kitchen" }
                });

            migrationBuilder.InsertData(
                table: "HighValueItems",
                columns: new[] { "Id", "CategoryId", "Name", "Value" },
                values: new object[,]
                {
                    { new Guid("ed83b44a-c141-4ea1-957f-9139888c54eb"), new Guid("bdf8686d-0fac-466e-9ac8-9bb73dc9db60"), "TV", 2000m },
                    { new Guid("38a4d2d5-74e7-47c9-8ca2-a1b0127ab313"), new Guid("bdf8686d-0fac-466e-9ac8-9bb73dc9db60"), "Playstation", 400m },
                    { new Guid("20903f7a-8d20-47fe-8598-e9c5eb35bc1c"), new Guid("bdf8686d-0fac-466e-9ac8-9bb73dc9db60"), "Stereo", 1600m },
                    { new Guid("8e31483d-ca49-46fd-a290-e0f1ccd6d1d4"), new Guid("4d0e5558-b897-4b8e-8754-9f4899719923"), "Shirts", 1100m },
                    { new Guid("fba4f3de-2879-4190-a5fd-c105f5dd0030"), new Guid("4d0e5558-b897-4b8e-8754-9f4899719923"), "Jeans", 1100m },
                    { new Guid("da700c43-0f53-46d3-8dd4-8ec120645f12"), new Guid("3daf2519-2dd0-47d7-9bdb-cb5f7c1b1b34"), "Pots and Pans", 3000m },
                    { new Guid("335d5ace-b761-4e12-974f-a04982d870d5"), new Guid("3daf2519-2dd0-47d7-9bdb-cb5f7c1b1b34"), "Flatware", 500m },
                    { new Guid("3222fd20-eeb7-4885-8cb8-213e69e0c942"), new Guid("3daf2519-2dd0-47d7-9bdb-cb5f7c1b1b34"), "Knife Set", 500m },
                    { new Guid("f16f4e68-17c9-4ba0-9e89-07da8f140501"), new Guid("3daf2519-2dd0-47d7-9bdb-cb5f7c1b1b34"), "Misc", 1000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HighValueItems_CategoryId",
                table: "HighValueItems",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HighValueItems");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
