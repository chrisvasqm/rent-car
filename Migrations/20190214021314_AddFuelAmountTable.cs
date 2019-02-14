using Microsoft.EntityFrameworkCore.Migrations;

namespace RentCar.Migrations
{
    public partial class AddFuelAmountTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_FuelAmount_FuelAmountId1",
                table: "Inspections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelAmount",
                table: "FuelAmount");

            migrationBuilder.RenameTable(
                name: "FuelAmount",
                newName: "FuelAmounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelAmounts",
                table: "FuelAmounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_FuelAmounts_FuelAmountId1",
                table: "Inspections",
                column: "FuelAmountId1",
                principalTable: "FuelAmounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inspections_FuelAmounts_FuelAmountId1",
                table: "Inspections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelAmounts",
                table: "FuelAmounts");

            migrationBuilder.RenameTable(
                name: "FuelAmounts",
                newName: "FuelAmount");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelAmount",
                table: "FuelAmount",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inspections_FuelAmount_FuelAmountId1",
                table: "Inspections",
                column: "FuelAmountId1",
                principalTable: "FuelAmount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
