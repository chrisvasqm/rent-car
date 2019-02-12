using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentCar.Migrations
{
    public partial class AddCommissionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AdmissionDate",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "CommissionId",
                table: "Employees",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "CommissionId1",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "StatusId",
                table: "Employees",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId1",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Commissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CommissionId1",
                table: "Employees",
                column: "CommissionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StatusId1",
                table: "Employees",
                column: "StatusId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Commissions_CommissionId1",
                table: "Employees",
                column: "CommissionId1",
                principalTable: "Commissions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Statuses_StatusId1",
                table: "Employees",
                column: "StatusId1",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Commissions_CommissionId1",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Statuses_StatusId1",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Commissions");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CommissionId1",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_StatusId1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AdmissionDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CommissionId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CommissionId1",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "StatusId1",
                table: "Employees");
        }
    }
}
