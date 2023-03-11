using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPI_vol2.Migrations
{
    public partial class IT_stuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Uzytkowniks");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Uzytkowniks");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Uzytkowniks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Uzytkowniks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imię",
                table: "Uzytkowniks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nazwisko",
                table: "Uzytkowniks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TelefonId",
                table: "Uzytkowniks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeviceTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaUrzadzenia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TelephonNos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumerTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PUK = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelephonNos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMEI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DomainName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceTypeId = table.Column<int>(type: "int", nullable: true),
                    UzytkownikID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_DeviceTypes_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalTable: "DeviceTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Devices_Uzytkowniks_UzytkownikID",
                        column: x => x.UzytkownikID,
                        principalTable: "Uzytkowniks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkowniks_DepartmentID",
                table: "Uzytkowniks",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkowniks_TelefonId",
                table: "Uzytkowniks",
                column: "TelefonId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceTypeId",
                table: "Devices",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UzytkownikID",
                table: "Devices",
                column: "UzytkownikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkowniks_Departments_DepartmentID",
                table: "Uzytkowniks",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkowniks_TelephonNos_TelefonId",
                table: "Uzytkowniks",
                column: "TelefonId",
                principalTable: "TelephonNos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkowniks_Departments_DepartmentID",
                table: "Uzytkowniks");

            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkowniks_TelephonNos_TelefonId",
                table: "Uzytkowniks");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "TelephonNos");

            migrationBuilder.DropTable(
                name: "DeviceTypes");

            migrationBuilder.DropIndex(
                name: "IX_Uzytkowniks_DepartmentID",
                table: "Uzytkowniks");

            migrationBuilder.DropIndex(
                name: "IX_Uzytkowniks_TelefonId",
                table: "Uzytkowniks");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Uzytkowniks");

            migrationBuilder.DropColumn(
                name: "Imię",
                table: "Uzytkowniks");

            migrationBuilder.DropColumn(
                name: "Nazwisko",
                table: "Uzytkowniks");

            migrationBuilder.DropColumn(
                name: "TelefonId",
                table: "Uzytkowniks");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Uzytkowniks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Uzytkowniks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Uzytkowniks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
