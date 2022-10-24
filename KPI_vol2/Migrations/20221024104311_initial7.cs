using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPI_vol2.Migrations
{
    public partial class initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zdarzenia_Status_StatusIdZdarzenia",
                table: "Zdarzenia");

            migrationBuilder.RenameColumn(
                name: "StatusIdZdarzenia",
                table: "Zdarzenia",
                newName: "StatusIdStatus");

            migrationBuilder.RenameIndex(
                name: "IX_Zdarzenia_StatusIdZdarzenia",
                table: "Zdarzenia",
                newName: "IX_Zdarzenia_StatusIdStatus");

            migrationBuilder.RenameColumn(
                name: "IdZdarzenia",
                table: "Status",
                newName: "IdStatus");

            migrationBuilder.AddColumn<int>(
                name: "IdStatus",
                table: "Zdarzenia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Zdarzenia_Status_StatusIdStatus",
                table: "Zdarzenia",
                column: "StatusIdStatus",
                principalTable: "Status",
                principalColumn: "IdStatus",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zdarzenia_Status_StatusIdStatus",
                table: "Zdarzenia");

            migrationBuilder.DropColumn(
                name: "IdStatus",
                table: "Zdarzenia");

            migrationBuilder.RenameColumn(
                name: "StatusIdStatus",
                table: "Zdarzenia",
                newName: "StatusIdZdarzenia");

            migrationBuilder.RenameIndex(
                name: "IX_Zdarzenia_StatusIdStatus",
                table: "Zdarzenia",
                newName: "IX_Zdarzenia_StatusIdZdarzenia");

            migrationBuilder.RenameColumn(
                name: "IdStatus",
                table: "Status",
                newName: "IdZdarzenia");

            migrationBuilder.AddForeignKey(
                name: "FK_Zdarzenia_Status_StatusIdZdarzenia",
                table: "Zdarzenia",
                column: "StatusIdZdarzenia",
                principalTable: "Status",
                principalColumn: "IdZdarzenia",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
