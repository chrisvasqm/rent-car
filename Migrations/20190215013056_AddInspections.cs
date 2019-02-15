﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentCar.Migrations
{
    public partial class AddInspections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    HasScratches = table.Column<bool>(nullable: false),
                    FuelAmountId = table.Column<byte>(nullable: false),
                    FuelAmountId1 = table.Column<int>(nullable: true),
                    HasReplacementTire = table.Column<bool>(nullable: false),
                    HasCatJack = table.Column<bool>(nullable: false),
                    HasBrokenGlass = table.Column<bool>(nullable: false),
                    IsFirstTireGood = table.Column<bool>(nullable: false),
                    IsSecondTireGood = table.Column<bool>(nullable: false),
                    IsThirdTireGood = table.Column<bool>(nullable: false),
                    IsFourthTireGood = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    StatusId = table.Column<byte>(nullable: false),
                    StatusId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspections_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspections_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspections_FuelAmountses_FuelAmountId1",
                        column: x => x.FuelAmountId1,
                        principalTable: "FuelAmountses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inspections_Statuses_StatusId1",
                        column: x => x.StatusId1,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inspections_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_ClientId",
                table: "Inspections",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_EmployeeId",
                table: "Inspections",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_FuelAmountId1",
                table: "Inspections",
                column: "FuelAmountId1");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_StatusId1",
                table: "Inspections",
                column: "StatusId1");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_VehicleId",
                table: "Inspections",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inspections");
        }
    }
}
