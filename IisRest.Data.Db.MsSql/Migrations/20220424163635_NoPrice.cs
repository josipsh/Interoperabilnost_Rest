using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IisRest.Data.Db.MsSql.Migrations
{
    public partial class NoPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldAssets_Prices_PriceId",
                table: "SoldAssets");

            migrationBuilder.DropIndex(
                name: "IX_SoldAssets_PriceId",
                table: "SoldAssets");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "SoldAssets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceId",
                table: "SoldAssets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SoldAssets_PriceId",
                table: "SoldAssets",
                column: "PriceId");

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
