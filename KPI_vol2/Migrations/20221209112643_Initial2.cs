using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPI_vol2.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Statusess_StatusByPosterId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statusess",
                table: "Statusess");

            migrationBuilder.RenameTable(
                name: "Statusess",
                newName: "PosterStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PosterStatus",
                table: "PosterStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_PosterStatus_StatusByPosterId",
                table: "Tasks",
                column: "StatusByPosterId",
                principalTable: "PosterStatus",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_PosterStatus_StatusByPosterId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PosterStatus",
                table: "PosterStatus");

            migrationBuilder.RenameTable(
                name: "PosterStatus",
                newName: "Statusess");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statusess",
                table: "Statusess",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Statusess_StatusByPosterId",
                table: "Tasks",
                column: "StatusByPosterId",
                principalTable: "Statusess",
                principalColumn: "Id");
        }
    }
}
