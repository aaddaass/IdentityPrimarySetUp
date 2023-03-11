using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPI_vol2.Migrations
{
    public partial class addDepartmentToZgloszenie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Zgloszenies",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CommentedOn",
                table: "Comments",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenies_DepartmentId",
                table: "Zgloszenies",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zgloszenies_Departments_DepartmentId",
                table: "Zgloszenies",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zgloszenies_Departments_DepartmentId",
                table: "Zgloszenies");

            migrationBuilder.DropIndex(
                name: "IX_Zgloszenies_DepartmentId",
                table: "Zgloszenies");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Zgloszenies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CommentedOn",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
