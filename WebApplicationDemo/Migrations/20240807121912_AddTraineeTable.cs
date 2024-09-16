using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddTraineeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Departments_DeptID",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Course_CourseID",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_DeptID",
                table: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_Course_DeptID",
                table: "Courses",
                newName: "IX_Courses_DeptID");

            migrationBuilder.AlterColumn<int>(
                name: "DeptID",
                table: "Instructors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "Instructors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DeptID",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    DeptID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Trainees_Departments_DeptID",
                        column: x => x.DeptID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_DeptID",
                table: "Trainees",
                column: "DeptID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DeptID",
                table: "Courses",
                column: "DeptID",
                principalTable: "Departments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Courses_CourseID",
                table: "Instructors",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_DeptID",
                table: "Instructors",
                column: "DeptID",
                principalTable: "Departments",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DeptID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Courses_CourseID",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_DeptID",
                table: "Instructors");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_DeptID",
                table: "Course",
                newName: "IX_Course_DeptID");

            migrationBuilder.AlterColumn<int>(
                name: "DeptID",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "Instructors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeptID",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Departments_DeptID",
                table: "Course",
                column: "DeptID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Course_CourseID",
                table: "Instructors",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_DeptID",
                table: "Instructors",
                column: "DeptID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
