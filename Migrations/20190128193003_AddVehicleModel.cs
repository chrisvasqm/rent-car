using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentCar.Migrations
{
    public partial class AddVehicleModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ChassisNumber = table.Column<string>(nullable: true),
                    MotorNumber = table.Column<string>(nullable: true),
                    LicensePlate = table.Column<string>(nullable: true),
                    VehicleTypeId = table.Column<byte>(nullable: false),
                    VehicleTypeId1 = table.Column<int>(nullable: true),
                    BrandId = table.Column<byte>(nullable: false),
                    BrandId1 = table.Column<int>(nullable: true),
                    ModelId = table.Column<byte>(nullable: false),
                    ModelId1 = table.Column<int>(nullable: true),
                    FuelTypeId = table.Column<byte>(nullable: false),
                    FuelTypeId1 = table.Column<int>(nullable: true),
                    StatusId = table.Column<byte>(nullable: false),
                    StatusId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Brands_BrandId1",
                        column: x => x.BrandId1,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_FuelTypes_FuelTypeId1",
                        column: x => x.FuelTypeId1,
                        principalTable: "FuelTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_Models_ModelId1",
                        column: x => x.ModelId1,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_Statuses_StatusId1",
                        column: x => x.StatusId1,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_VehicleTypeId1",
                        column: x => x.VehicleTypeId1,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_BrandId1",
                table: "Vehicles",
                column: "BrandId1");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FuelTypeId1",
                table: "Vehicles",
                column: "FuelTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId1",
                table: "Vehicles",
                column: "ModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_StatusId1",
                table: "Vehicles",
                column: "StatusId1");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId1",
                table: "Vehicles",
                column: "VehicleTypeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}