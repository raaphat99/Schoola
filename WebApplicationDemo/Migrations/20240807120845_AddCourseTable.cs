using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseDegree = table.Column<int>(type: "int", nullable: false),
                    PassDegree = table.Column<int>(type: "int", nullable: false),
                    DeptID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Course_Departments_DeptID",
                        column: x => x.DeptID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_CourseID",
                table: "Instructors",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DeptID",
                table: "Course",
                column: "DeptID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Course_CourseID",
                table: "Instructors",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Course_CourseID",
                table: "Instructors");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_CourseID",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Instructors");
        }
    }
}
