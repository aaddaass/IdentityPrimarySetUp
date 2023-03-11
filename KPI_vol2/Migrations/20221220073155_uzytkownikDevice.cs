using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPI_vol2.Migrations
{
    public partial class uzytkownikDevice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Uzytkowniks_UzytkownikID",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_UzytkownikID",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "UzytkownikID",
                table: "Devices");

            migrationBuilder.CreateTable(
                name: "UzytkownikDevices",
                columns: table => new
                {
                    UzytkownikID = table.Column<int>(type: "int", nullable: false),
                    DeviceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UzytkownikDevices", x => new { x.DeviceID, x.UzytkownikID });
                    table.ForeignKey(
                        name: "FK_UzytkownikDevices_Devices_DeviceID",
                        column: x => x.DeviceID,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UzytkownikDevices_Uzytkowniks_UzytkownikID",
                        column: x => x.UzytkownikID,
                        principalTable: "Uzytkowniks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UzytkownikDevices_UzytkownikID",
                table: "UzytkownikDevices",
                column: "UzytkownikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UzytkownikDevices");

            migrationBuilder.AddColumn<int>(
                name: "UzytkownikID",
                table: "Devices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UzytkownikID",
                table: "Devices",
                column: "UzytkownikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Uzytkowniks_UzytkownikID",
                table: "Devices",
                column: "UzytkownikID",
                principalTable: "Uzytkowniks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
