using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPI_vol2.Migrations
{
    public partial class deleteDepartmentfromTask2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zgloszenies_Departments_DepartmentsId",
                table: "Zgloszenies");

            migrationBuilder.DropIndex(
                name: "IX_Zgloszenies_DepartmentsId",
                table: "Zgloszenies");

            migrationBuilder.DropColumn(
                name: "DepartmentsId",
                table: "Zgloszenies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentsId",
                table: "Zgloszenies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenies_DepartmentsId",
                table: "Zgloszenies",
                column: "DepartmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zgloszenies_Departments_DepartmentsId",
                table: "Zgloszenies",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
