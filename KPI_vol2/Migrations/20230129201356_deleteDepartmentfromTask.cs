using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPI_vol2.Migrations
{
    public partial class deleteDepartmentfromTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zgloszenies_Departments_DepartmentId",
                table: "Zgloszenies");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Zgloszenies",
                newName: "DepartmentsId");

            migrationBuilder.RenameIndex(
                name: "IX_Zgloszenies_DepartmentId",
                table: "Zgloszenies",
                newName: "IX_Zgloszenies_DepartmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zgloszenies_Departments_DepartmentsId",
                table: "Zgloszenies",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zgloszenies_Departments_DepartmentsId",
                table: "Zgloszenies");

            migrationBuilder.RenameColumn(
                name: "DepartmentsId",
                table: "Zgloszenies",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Zgloszenies_DepartmentsId",
                table: "Zgloszenies",
                newName: "IX_Zgloszenies_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zgloszenies_Departments_DepartmentId",
                table: "Zgloszenies",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
