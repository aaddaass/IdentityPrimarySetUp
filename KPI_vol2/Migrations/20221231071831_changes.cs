using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPI_vol2.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UzytkownikDevices_Devices_DeviceID",
                table: "UzytkownikDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_UzytkownikDevices_Uzytkowniks_UzytkownikID",
                table: "UzytkownikDevices");

            migrationBuilder.AddColumn<int>(
                name: "UzytkownikDeviceDeviceID",
                table: "Uzytkowniks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UzytkownikDeviceUzytkownikID",
                table: "Uzytkowniks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UzytkownikDeviceDeviceID",
                table: "Devices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UzytkownikDeviceUzytkownikID",
                table: "Devices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkowniks_UzytkownikDeviceDeviceID_UzytkownikDeviceUzytkownikID",
                table: "Uzytkowniks",
                columns: new[] { "UzytkownikDeviceDeviceID", "UzytkownikDeviceUzytkownikID" });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UzytkownikDeviceDeviceID_UzytkownikDeviceUzytkownikID",
                table: "Devices",
                columns: new[] { "UzytkownikDeviceDeviceID", "UzytkownikDeviceUzytkownikID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_UzytkownikDevices_UzytkownikDeviceDeviceID_UzytkownikDeviceUzytkownikID",
                table: "Devices",
                columns: new[] { "UzytkownikDeviceDeviceID", "UzytkownikDeviceUzytkownikID" },
                principalTable: "UzytkownikDevices",
                principalColumns: new[] { "DeviceID", "UzytkownikID" });

            migrationBuilder.AddForeignKey(
                name: "FK_UzytkownikDevices_Devices_DeviceID",
                table: "UzytkownikDevices",
                column: "DeviceID",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UzytkownikDevices_Uzytkowniks_UzytkownikID",
                table: "UzytkownikDevices",
                column: "UzytkownikID",
                principalTable: "Uzytkowniks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkowniks_UzytkownikDevices_UzytkownikDeviceDeviceID_UzytkownikDeviceUzytkownikID",
                table: "Uzytkowniks",
                columns: new[] { "UzytkownikDeviceDeviceID", "UzytkownikDeviceUzytkownikID" },
                principalTable: "UzytkownikDevices",
                principalColumns: new[] { "DeviceID", "UzytkownikID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_UzytkownikDevices_UzytkownikDeviceDeviceID_UzytkownikDeviceUzytkownikID",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_UzytkownikDevices_Devices_DeviceID",
                table: "UzytkownikDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_UzytkownikDevices_Uzytkowniks_UzytkownikID",
                table: "UzytkownikDevices");

            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkowniks_UzytkownikDevices_UzytkownikDeviceDeviceID_UzytkownikDeviceUzytkownikID",
                table: "Uzytkowniks");

            migrationBuilder.DropIndex(
                name: "IX_Uzytkowniks_UzytkownikDeviceDeviceID_UzytkownikDeviceUzytkownikID",
                table: "Uzytkowniks");

            migrationBuilder.DropIndex(
                name: "IX_Devices_UzytkownikDeviceDeviceID_UzytkownikDeviceUzytkownikID",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "UzytkownikDeviceDeviceID",
                table: "Uzytkowniks");

            migrationBuilder.DropColumn(
                name: "UzytkownikDeviceUzytkownikID",
                table: "Uzytkowniks");

            migrationBuilder.DropColumn(
                name: "UzytkownikDeviceDeviceID",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "UzytkownikDeviceUzytkownikID",
                table: "Devices");

            migrationBuilder.AddForeignKey(
                name: "FK_UzytkownikDevices_Devices_DeviceID",
                table: "UzytkownikDevices",
                column: "DeviceID",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UzytkownikDevices_Uzytkowniks_UzytkownikID",
                table: "UzytkownikDevices",
                column: "UzytkownikID",
                principalTable: "Uzytkowniks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
