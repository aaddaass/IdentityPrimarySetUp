using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPI_vol2.Data.Migrations
{
    public partial class status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdStatus",
                table: "Zdarzenia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusIdStatus",
                table: "Zdarzenia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.IdStatus);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zdarzenia_StatusIdStatus",
                table: "Zdarzenia",
                column: "StatusIdStatus");

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

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Zdarzenia_StatusIdStatus",
                table: "Zdarzenia");

            migrationBuilder.DropColumn(
                name: "IdStatus",
                table: "Zdarzenia");

            migrationBuilder.DropColumn(
                name: "StatusIdStatus",
                table: "Zdarzenia");
        }
    }
}
