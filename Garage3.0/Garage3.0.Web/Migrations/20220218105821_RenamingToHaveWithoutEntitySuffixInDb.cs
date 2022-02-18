using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage3._0.Web.Migrations
{
    public partial class RenamingToHaveWithoutEntitySuffixInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleEntity_MemberEntity_MemberEntityId",
                table: "VehicleEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleEntity_VehicleTypeEntity_VehicleTypeEntityId",
                table: "VehicleEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleTypeEntity",
                table: "VehicleTypeEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleEntity",
                table: "VehicleEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberEntity",
                table: "MemberEntity");

            migrationBuilder.RenameTable(
                name: "VehicleTypeEntity",
                newName: "VehicleTypes");

            migrationBuilder.RenameTable(
                name: "VehicleEntity",
                newName: "Vehicles");

            migrationBuilder.RenameTable(
                name: "MemberEntity",
                newName: "Members");

            migrationBuilder.RenameColumn(
                name: "VehicleTypeEntityId",
                table: "Vehicles",
                newName: "VehicleTypeId");

            migrationBuilder.RenameColumn(
                name: "MemberEntityId",
                table: "Vehicles",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleEntity_VehicleTypeEntityId",
                table: "Vehicles",
                newName: "IX_Vehicles_VehicleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleEntity_MemberEntityId",
                table: "Vehicles",
                newName: "IX_Vehicles_MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleTypes",
                table: "VehicleTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Members_MemberId",
                table: "Vehicles",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Members_MemberId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleTypes",
                table: "VehicleTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.RenameTable(
                name: "VehicleTypes",
                newName: "VehicleTypeEntity");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "VehicleEntity");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "MemberEntity");

            migrationBuilder.RenameColumn(
                name: "VehicleTypeId",
                table: "VehicleEntity",
                newName: "VehicleTypeEntityId");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "VehicleEntity",
                newName: "MemberEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "VehicleEntity",
                newName: "IX_VehicleEntity_VehicleTypeEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_MemberId",
                table: "VehicleEntity",
                newName: "IX_VehicleEntity_MemberEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleTypeEntity",
                table: "VehicleTypeEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleEntity",
                table: "VehicleEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberEntity",
                table: "MemberEntity",
                column: "Id");

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
    }
}
