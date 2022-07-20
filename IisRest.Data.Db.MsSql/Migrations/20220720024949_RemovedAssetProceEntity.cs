using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IisRest.Data.Db.MsSql.Migrations
{
    public partial class RemovedAssetProceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoughtAssets_AssetPrices_AssetPriceId",
                table: "BoughtAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_SoldAssets_AssetPrices_AssetPriceId",
                table: "SoldAssets");

            migrationBuilder.DropTable(
                name: "AssetPrices");

            migrationBuilder.RenameColumn(
                name: "AssetPriceId",
                table: "SoldAssets",
                newName: "PriceId");

            migrationBuilder.RenameIndex(
                name: "IX_SoldAssets_AssetPriceId",
                table: "SoldAssets",
                newName: "IX_SoldAssets_PriceId");

            migrationBuilder.RenameColumn(
                name: "AssetPriceId",
                table: "BoughtAssets",
                newName: "PriceId");

            migrationBuilder.RenameIndex(
                name: "IX_BoughtAssets_AssetPriceId",
                table: "BoughtAssets",
                newName: "IX_BoughtAssets_PriceId");

            migrationBuilder.AddColumn<int>(
                name: "AssetId",
                table: "SoldAssets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AssetId",
                table: "BoughtAssets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SoldAssets_AssetId",
                table: "SoldAssets",
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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BoughtAssets_Prices_PriceId",
                table: "BoughtAssets",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SoldAssets_Assets_AssetId",
                table: "SoldAssets",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SoldAssets_Prices_PriceId",
                table: "SoldAssets",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoughtAssets_Assets_AssetId",
                table: "BoughtAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_BoughtAssets_Prices_PriceId",
                table: "BoughtAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_SoldAssets_Assets_AssetId",
                table: "SoldAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_SoldAssets_Prices_PriceId",
                table: "SoldAssets");

            migrationBuilder.DropIndex(
                name: "IX_SoldAssets_AssetId",
                table: "SoldAssets");

            migrationBuilder.DropIndex(
                name: "IX_BoughtAssets_AssetId",
                table: "BoughtAssets");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "SoldAssets");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "BoughtAssets");

            migrationBuilder.RenameColumn(
                name: "PriceId",
                table: "SoldAssets",
                newName: "AssetPriceId");

            migrationBuilder.RenameIndex(
                name: "IX_SoldAssets_PriceId",
                table: "SoldAssets",
                newName: "IX_SoldAssets_AssetPriceId");

            migrationBuilder.RenameColumn(
                name: "PriceId",
                table: "BoughtAssets",
                newName: "AssetPriceId");

            migrationBuilder.RenameIndex(
                name: "IX_BoughtAssets_PriceId",
                table: "BoughtAssets",
                newName: "IX_BoughtAssets_AssetPriceId");

            migrationBuilder.CreateTable(
                name: "AssetPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", nullable: false),
                    PriceId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssetPrices_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetPrices_Prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetPrices_AssetId",
                table: "AssetPrices",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetPrices_PriceId",
                table: "AssetPrices",
                column: "PriceId",
                unique: true);

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
    }
}
