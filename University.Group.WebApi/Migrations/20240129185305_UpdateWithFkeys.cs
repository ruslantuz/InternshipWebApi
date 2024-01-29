using Microsoft.EntityFrameworkCore.Migrations;

namespace University.Group.WebApi.Migrations
{
    public partial class UpdateWithFkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Groups",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_DepartmentId",
                table: "Groups",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Departments_DepartmentId",
                table: "Groups",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Departments_DepartmentId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_DepartmentId",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Groups",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
