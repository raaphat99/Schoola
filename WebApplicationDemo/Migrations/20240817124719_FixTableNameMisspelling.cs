using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationDemo.Migrations
{
    /// <inheritdoc />
    public partial class FixTableNameMisspelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentID",
                table: "CourseDepartment");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "CourseDepartment",
                newName: "DepartmentsID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDepartment_DepartmentID",
                table: "CourseDepartment",
                newName: "IX_CourseDepartment_DepartmentsID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentsID",
                table: "CourseDepartment",
                column: "DepartmentsID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentsID",
                table: "CourseDepartment");

            migrationBuilder.RenameColumn(
                name: "DepartmentsID",
                table: "CourseDepartment",
                newName: "DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDepartment_DepartmentsID",
                table: "CourseDepartment",
                newName: "IX_CourseDepartment_DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentID",
                table: "CourseDepartment",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
