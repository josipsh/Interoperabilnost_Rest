using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IisRest.Data.Db.MsSql.Migrations
{
    public partial class ReafctoredFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoughtAssets_Prices_PriceId",
                table: "BoughtAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_SoldAssets_Prices_PriceId",
                table: "SoldAssets");

            migrationBuilder.DropIndex(
                name: "IX_SoldAssets_PriceId",
                table: "SoldAssets");

            migrationBuilder.DropIndex(
                name: "IX_BoughtAssets_PriceId",
                table: "BoughtAssets");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "SoldAssets");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "BoughtAssets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "SoldAssets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "BoughtAssets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SoldAssets_PriceId",
                table: "SoldAssets",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_BoughtAssets_PriceId",
                table: "BoughtAssets",
                column: "PriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoughtAssets_Prices_PriceId",
                table: "BoughtAssets",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoldAssets_Prices_PriceId",
                table: "SoldAssets",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
