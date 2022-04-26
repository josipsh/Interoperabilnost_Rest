using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IisRest.Data.Db.MsSql.Migrations
{
    public partial class UpdatedAssetProceTableConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetPrice_Assets_AssetId",
                table: "AssetPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetPrice_BoughtAssets_PriceId",
                table: "AssetPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetPrice_Prices_PriceId",
                table: "AssetPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetPrice_SoldAssets_PriceId",
                table: "AssetPrice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetPrice",
                table: "AssetPrice");

            migrationBuilder.RenameTable(
                name: "AssetPrice",
                newName: "AssetPrices");

            migrationBuilder.RenameIndex(
                name: "IX_AssetPrice_PriceId",
                table: "AssetPrices",
                newName: "IX_AssetPrices_PriceId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetPrice_AssetId",
                table: "AssetPrices",
                newName: "IX_AssetPrices_AssetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetPrices",
                table: "AssetPrices",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SoldAssets_AssetPriceId",
                table: "SoldAssets",
                column: "AssetPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_BoughtAssets_AssetPriceId",
                table: "BoughtAssets",
                column: "AssetPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetPrices_Assets_AssetId",
                table: "AssetPrices",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetPrices_Prices_PriceId",
                table: "AssetPrices",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BoughtAssets_AssetPrices_AssetPriceId",
                table: "BoughtAssets",
                column: "AssetPriceId",
                principalTable: "AssetPrices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SoldAssets_AssetPrices_AssetPriceId",
                table: "SoldAssets",
                column: "AssetPriceId",
                principalTable: "AssetPrices",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetPrices_Assets_AssetId",
                table: "AssetPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetPrices_Prices_PriceId",
                table: "AssetPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_BoughtAssets_AssetPrices_AssetPriceId",
                table: "BoughtAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_SoldAssets_AssetPrices_AssetPriceId",
                table: "SoldAssets");

            migrationBuilder.DropIndex(
                name: "IX_SoldAssets_AssetPriceId",
                table: "SoldAssets");

            migrationBuilder.DropIndex(
                name: "IX_BoughtAssets_AssetPriceId",
                table: "BoughtAssets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetPrices",
                table: "AssetPrices");

            migrationBuilder.RenameTable(
                name: "AssetPrices",
                newName: "AssetPrice");

            migrationBuilder.RenameIndex(
                name: "IX_AssetPrices_PriceId",
                table: "AssetPrice",
                newName: "IX_AssetPrice_PriceId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetPrices_AssetId",
                table: "AssetPrice",
                newName: "IX_AssetPrice_AssetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetPrice",
                table: "AssetPrice",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetPrice_Assets_AssetId",
                table: "AssetPrice",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetPrice_BoughtAssets_PriceId",
                table: "AssetPrice",
                column: "PriceId",
                principalTable: "BoughtAssets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetPrice_Prices_PriceId",
                table: "AssetPrice",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetPrice_SoldAssets_PriceId",
                table: "AssetPrice",
                column: "PriceId",
                principalTable: "SoldAssets",
                principalColumn: "Id");
        }
    }
}
