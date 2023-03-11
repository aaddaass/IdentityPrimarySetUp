using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPI_vol2.Migrations
{
    public partial class zgloszenieTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tasks_AttachedToTaskId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "AssignerStatus");

            migrationBuilder.DropTable(
                name: "PosterStatus");

            migrationBuilder.CreateTable(
                name: "Zgloszenies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    AssignedToId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PriorityId = table.Column<int>(type: "int", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkingAreaId = table.Column<int>(type: "int", nullable: true),
                    StatusByAssigned_Id = table.Column<int>(type: "int", nullable: true),
                    StatusByPoster_Id = table.Column<int>(type: "int", nullable: true),
                    StatusIdStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zgloszenies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zgloszenies_AspNetUsers_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Zgloszenies_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zgloszenies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zgloszenies_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zgloszenies_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zgloszenies_Statuses_StatusByAssigned_Id",
                        column: x => x.StatusByAssigned_Id,
                        principalTable: "Statuses",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zgloszenies_Statuses_StatusByPoster_Id",
                        column: x => x.StatusByPoster_Id,
                        principalTable: "Statuses",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zgloszenies_Statuses_StatusIdStatus",
                        column: x => x.StatusIdStatus,
                        principalTable: "Statuses",
                        principalColumn: "IdStatus");
                    table.ForeignKey(
                        name: "FK_Zgloszenies_WorkingAreas_WorkingAreaId",
                        column: x => x.WorkingAreaId,
                        principalTable: "WorkingAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenies_AssignedToId",
                table: "Zgloszenies",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenies_CategoryId",
                table: "Zgloszenies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenies_DepartmentId",
                table: "Zgloszenies",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenies_PriorityId",
                table: "Zgloszenies",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenies_StatusByAssigned_Id",
                table: "Zgloszenies",
                column: "StatusByAssigned_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenies_StatusByPoster_Id",
                table: "Zgloszenies",
                column: "StatusByPoster_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenies_StatusIdStatus",
                table: "Zgloszenies",
                column: "StatusIdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenies_UserID",
                table: "Zgloszenies",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenies_WorkingAreaId",
                table: "Zgloszenies",
                column: "WorkingAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Zgloszenies_AttachedToTaskId",
                table: "Comments",
                column: "AttachedToTaskId",
                principalTable: "Zgloszenies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Zgloszenies_AttachedToTaskId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Zgloszenies");

            migrationBuilder.CreateTable(
                name: "AssignerStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignerStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PosterStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosterStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedToId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    PosterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PriorityId = table.Column<int>(type: "int", nullable: true),
                    StatusByAssignedId = table.Column<int>(type: "int", nullable: true),
                    StatusByPosterId = table.Column<int>(type: "int", nullable: true),
                    WorkingAreaId = table.Column<int>(type: "int", nullable: true),
                    ClosedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_PosterId",
                        column: x => x.PosterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_AssignerStatus_StatusByAssignedId",
                        column: x => x.StatusByAssignedId,
                        principalTable: "AssignerStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_PosterStatus_StatusByPosterId",
                        column: x => x.StatusByPosterId,
                        principalTable: "PosterStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_WorkingAreas_WorkingAreaId",
                        column: x => x.WorkingAreaId,
                        principalTable: "WorkingAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedToId",
                table: "Tasks",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CategoryId",
                table: "Tasks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_DepartmentId",
                table: "Tasks",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PosterId",
                table: "Tasks",
                column: "PosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PriorityId",
                table: "Tasks",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusByAssignedId",
                table: "Tasks",
                column: "StatusByAssignedId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusByPosterId",
                table: "Tasks",
                column: "StatusByPosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_WorkingAreaId",
                table: "Tasks",
                column: "WorkingAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tasks_AttachedToTaskId",
                table: "Comments",
                column: "AttachedToTaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
