using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage3._0.Web.Migrations
{
    public partial class AddRelationVehicleAndVehicleType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VehicleType",
                table: "VehicleEntity",
                newName: "VehicleTypeId");

            migrationBuilder.CreateTable(
                name: "VehicleTypeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wheels = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypeEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleEntity_VehicleTypeId",
                table: "VehicleEntity",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleEntity_VehicleTypeEntity_VehicleTypeId",
                table: "VehicleEntity",
                column: "VehicleTypeId",
                principalTable: "VehicleTypeEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleEntity_VehicleTypeEntity_VehicleTypeId",
                table: "VehicleEntity");

            migrationBuilder.DropTable(
                name: "VehicleTypeEntity");

            migrationBuilder.DropIndex(
                name: "IX_VehicleEntity_VehicleTypeId",
                table: "VehicleEntity");

            migrationBuilder.RenameColumn(
                name: "VehicleTypeId",
                table: "VehicleEntity",
                newName: "VehicleType");
        }
    }
}
