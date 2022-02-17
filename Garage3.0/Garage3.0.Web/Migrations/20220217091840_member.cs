using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage3._0.Web.Migrations
{
    public partial class member : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberEntityId",
                table: "VehicleEntity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MemberEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonNr = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleTypes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleEntity_MemberEntityId",
                table: "VehicleEntity",
                column: "MemberEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleEntity_MemberEntity_MemberEntityId",
                table: "VehicleEntity",
                column: "MemberEntityId",
                principalTable: "MemberEntity",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleEntity_MemberEntity_MemberEntityId",
                table: "VehicleEntity");

            migrationBuilder.DropTable(
                name: "MemberEntity");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropIndex(
                name: "IX_VehicleEntity_MemberEntityId",
                table: "VehicleEntity");

            migrationBuilder.DropColumn(
                name: "MemberEntityId",
                table: "VehicleEntity");
        }
    }
}
