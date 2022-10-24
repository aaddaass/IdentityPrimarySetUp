using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPI_vol2.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdZdarzenia",
                table: "Zdarzenia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusIdZdarzenia",
                table: "Zdarzenia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    IdZdarzenia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.IdZdarzenia);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zdarzenia_StatusIdZdarzenia",
                table: "Zdarzenia",
                column: "StatusIdZdarzenia");

            migrationBuilder.AddForeignKey(
                name: "FK_Zdarzenia_Status_StatusIdZdarzenia",
                table: "Zdarzenia",
                column: "StatusIdZdarzenia",
                principalTable: "Status",
                principalColumn: "IdZdarzenia",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zdarzenia_Status_StatusIdZdarzenia",
                table: "Zdarzenia");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Zdarzenia_StatusIdZdarzenia",
                table: "Zdarzenia");

            migrationBuilder.DropColumn(
                name: "IdZdarzenia",
                table: "Zdarzenia");

            migrationBuilder.DropColumn(
                name: "StatusIdZdarzenia",
                table: "Zdarzenia");
        }
    }
}
