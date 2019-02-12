using Microsoft.EntityFrameworkCore.Migrations;

namespace RentCar.Migrations
{
    public partial class AddWorkShiftsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_WorkShift_WorkShiftId1",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkShift",
                table: "WorkShift");

            migrationBuilder.RenameTable(
                name: "WorkShift",
                newName: "WorkShifts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkShifts",
                table: "WorkShifts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_WorkShifts_WorkShiftId1",
                table: "Employees",
                column: "WorkShiftId1",
                principalTable: "WorkShifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_WorkShifts_WorkShiftId1",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkShifts",
                table: "WorkShifts");

            migrationBuilder.RenameTable(
                name: "WorkShifts",
                newName: "WorkShift");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkShift",
                table: "WorkShift",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_WorkShift_WorkShiftId1",
                table: "Employees",
                column: "WorkShiftId1",
                principalTable: "WorkShift",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
