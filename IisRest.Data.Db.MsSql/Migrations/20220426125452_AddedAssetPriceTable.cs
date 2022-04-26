using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IisRest.Data.Db.MsSql.Migrations
{
    public partial class AddedAssetPriceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoughtAssets_Assets_AssetId",
                table: "BoughtAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_Prices_Assets_AssetId",
                table: "Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_SoldAssets_Assets_AssetId",
                table: "SoldAssets");

            migrationBuilder.DropIndex(
                name: "IX_SoldAssets_AssetId",
                table: "SoldAssets");

            migrationBuilder.DropIndex(
                name: "IX_Prices_AssetId",
                table: "Prices");

            migrationBuilder.DropIndex(
                name: "IX_BoughtAssets_AssetId",
                table: "BoughtAssets");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "Prices");

            migrationBuilder.RenameColumn(
                name: "AssetId",
                table: "SoldAssets",
                newName: "AssetPriceId");

            migrationBuilder.RenameColumn(
                name: "AssetId",
                table: "BoughtAssets",
                newName: "AssetPriceId");

            migrationBuilder.CreateTable(
                name: "AssetPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceId = table.Column<int>(type: "int", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetPrice_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetPrice_BoughtAssets_PriceId",
                        column: x => x.PriceId,
                        principalTable: "BoughtAssets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssetPrice_Prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetPrice_SoldAssets_PriceId",
                        column: x => x.PriceId,
                        principalTable: "SoldAssets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetPrice_AssetId",
                table: "AssetPrice",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetPrice_PriceId",
                table: "AssetPrice",
                column: "PriceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetPrice");

            migrationBuilder.RenameColumn(
                name: "AssetPriceId",
                table: "SoldAssets",
                newName: "AssetId");

            migrationBuilder.RenameColumn(
                name: "AssetPriceId",
                table: "BoughtAssets",
                newName: "AssetId");

            migrationBuilder.AddColumn<int>(
                name: "AssetId",
                table: "Prices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SoldAssets_AssetId",
                table: "SoldAssets",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_AssetId",
                table: "Prices",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_BoughtAssets_AssetId",
                table: "BoughtAssets",
                column: "AssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoughtAssets_Assets_AssetId",
                table: "BoughtAssets",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prices_Assets_AssetId",
                table: "Prices",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SoldAssets_Assets_AssetId",
                table: "SoldAssets",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
