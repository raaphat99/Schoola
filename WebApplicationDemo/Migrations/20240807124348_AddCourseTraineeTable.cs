using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseTraineeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Departments_DeptID",
                table: "Trainees");

            migrationBuilder.AlterColumn<int>(
                name: "DeptID",
                table: "Trainees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CourseTrainees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoruseID = table.Column<int>(type: "int", nullable: false),
                    TrineeID = table.Column<int>(type: "int", nullable: false),
                    TraineeDegree = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTrainees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourseTrainees_Courses_CoruseID",
                        column: x => x.CoruseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseTrainees_Trainees_TrineeID",
                        column: x => x.TrineeID,
                        principalTable: "Trainees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTrainees_CoruseID",
                table: "CourseTrainees",
                column: "CoruseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTrainees_TrineeID",
                table: "CourseTrainees",
                column: "TrineeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Departments_DeptID",
                table: "Trainees",
                column: "DeptID",
                principalTable: "Departments",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Departments_DeptID",
                table: "Trainees");

            migrationBuilder.DropTable(
                name: "CourseTrainees");

            migrationBuilder.AlterColumn<int>(
                name: "DeptID",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Departments_DeptID",
                table: "Trainees",
                column: "DeptID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
