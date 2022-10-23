﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPI_vol2.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zdarzenia_Statuses_StatusIdStatus",
                table: "Zdarzenia");

            migrationBuilder.DropIndex(
                name: "IX_Zdarzenia_StatusIdStatus",
                table: "Zdarzenia");

            migrationBuilder.DropColumn(
                name: "StatusIdStatus",
                table: "Zdarzenia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusIdStatus",
                table: "Zdarzenia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zdarzenia_StatusIdStatus",
                table: "Zdarzenia",
                column: "StatusIdStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_Zdarzenia_Statuses_StatusIdStatus",
                table: "Zdarzenia",
                column: "StatusIdStatus",
                principalTable: "Statuses",
                principalColumn: "IdStatus",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
