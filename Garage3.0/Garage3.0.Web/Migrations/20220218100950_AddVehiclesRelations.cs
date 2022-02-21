using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage3._0.Web.Migrations
{
    public partial class AddVehiclesRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VehicleEntity_MemberEntityId",
                table: "VehicleEntity",
                column: "MemberEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleEntity_VehicleTypeEntityId",
                table: "VehicleEntity",
                column: "VehicleTypeEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleEntity_MemberEntity_MemberEntityId",
                table: "VehicleEntity",
                column: "MemberEntityId",
                principalTable: "MemberEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleEntity_VehicleTypeEntity_VehicleTypeEntityId",
                table: "VehicleEntity",
                column: "VehicleTypeEntityId",
                principalTable: "VehicleTypeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleEntity_MemberEntity_MemberEntityId",
                table: "VehicleEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleEntity_VehicleTypeEntity_VehicleTypeEntityId",
                table: "VehicleEntity");

            migrationBuilder.DropIndex(
                name: "IX_VehicleEntity_MemberEntityId",
                table: "VehicleEntity");

            migrationBuilder.DropIndex(
                name: "IX_VehicleEntity_VehicleTypeEntityId",
                table: "VehicleEntity");
        }
    }
}
