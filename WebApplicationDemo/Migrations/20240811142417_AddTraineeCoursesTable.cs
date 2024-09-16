using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddTraineeCoursesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TraineeCourses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    TraineeID = table.Column<int>(type: "int", nullable: false),
                    TraineeDegree = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeCourses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TraineeCourses_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TraineeCourses_Trainees_TraineeID",
                        column: x => x.TraineeID,
                        principalTable: "Trainees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TraineeCourses_CourseID",
                table: "TraineeCourses",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeCourses_TraineeID",
                table: "TraineeCourses",
                column: "TraineeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TraineeCourses");

            migrationBuilder.CreateTable(
                name: "CourseTrainees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    TraineeID = table.Column<int>(type: "int", nullable: false),
                    TraineeDegree = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTrainees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourseTrainees_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseTrainees_Trainees_TraineeID",
                        column: x => x.TraineeID,
                        principalTable: "Trainees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTrainees_CourseID",
                table: "CourseTrainees",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTrainees_TraineeID",
                table: "CourseTrainees",
                column: "TraineeID");
        }
    }
}
