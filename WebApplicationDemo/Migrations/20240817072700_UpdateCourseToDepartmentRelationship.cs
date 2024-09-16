using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationDemo.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCourseToDepartmentRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DeptID",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DeptID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DeptID",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "CourseDepartment",
                columns: table => new
                {
                    CoursesID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDepartment", x => new { x.CoursesID, x.DepartmentID });
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Courses_CoursesID",
                        column: x => x.CoursesID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDepartment_DepartmentID",
                table: "CourseDepartment",
                column: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDepartment");

            migrationBuilder.AddColumn<int>(
                name: "DeptID",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DeptID",
                table: "Courses",
                column: "DeptID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DeptID",
                table: "Courses",
                column: "DeptID",
                principalTable: "Departments",
                principalColumn: "ID");
        }
    }
}
