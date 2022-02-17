using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage3._0.Web.Migrations
{
    public partial class RenameVehicleTableInDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleEntity_VehicleTypeEntity_VehicleTypeId",
                table: "VehicleEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleEntity",
                table: "VehicleEntity");

            migrationBuilder.RenameTable(
                name: "VehicleEntity",
                newName: "Vehicle");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleEntity_VehicleTypeId",
                table: "Vehicle",
                newName: "IX_Vehicle_VehicleTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleTypeEntity_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId",
                principalTable: "VehicleTypeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleTypeEntity_VehicleTypeId",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "VehicleEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "VehicleEntity",
                newName: "IX_VehicleEntity_VehicleTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleEntity",
                table: "VehicleEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleEntity_VehicleTypeEntity_VehicleTypeId",
                table: "VehicleEntity",
                column: "VehicleTypeId",
                principalTable: "VehicleTypeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
