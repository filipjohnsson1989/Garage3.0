using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage3._0.Web.Migrations
{
    public partial class AddParkingAktivities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Member",
                table: "VehicleEntity");

            migrationBuilder.DropColumn(
                name: "VehicleType",
                table: "VehicleEntity");

            migrationBuilder.RenameColumn(
                name: "MemberEntityId",
                table: "VehicleEntity",
                newName: "VehicleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleEntity_MemberEntityId",
                table: "VehicleEntity",
                newName: "IX_VehicleEntity_VehicleTypeId");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "VehicleEntity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ParkingActivityEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ParkingCost = table.Column<double>(type: "float", nullable: true),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingActivityEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingActivityEntity_VehicleEntity_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehicleEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleEntity_MemberId",
                table: "VehicleEntity",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingActivityEntity_VehicleId",
                table: "ParkingActivityEntity",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleEntity_MemberEntity_MemberId",
                table: "VehicleEntity",
                column: "MemberId",
                principalTable: "MemberEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleEntity_VehicleTypeEntity_VehicleTypeId",
                table: "VehicleEntity",
                column: "VehicleTypeId",
                principalTable: "VehicleTypeEntity",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleEntity_MemberEntity_MemberId",
                table: "VehicleEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleEntity_VehicleTypeEntity_VehicleTypeId",
                table: "VehicleEntity");

            migrationBuilder.DropTable(
                name: "ParkingActivityEntity");

            migrationBuilder.DropIndex(
                name: "IX_VehicleEntity_MemberId",
                table: "VehicleEntity");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "VehicleEntity");

            migrationBuilder.RenameColumn(
                name: "VehicleTypeId",
                table: "VehicleEntity",
                newName: "MemberEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleEntity_VehicleTypeId",
                table: "VehicleEntity",
                newName: "IX_VehicleEntity_MemberEntityId");

            migrationBuilder.AddColumn<int>(
                name: "Member",
                table: "VehicleEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VehicleType",
                table: "VehicleEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
