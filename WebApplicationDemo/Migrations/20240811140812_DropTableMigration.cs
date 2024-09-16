using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationDemo.Migrations
{
    /// <inheritdoc />
    public partial class DropTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //migrationBuilder.DropForeignKey(
            //    name: "FK_CourseTrainees_Courses_CoruseID",
            //    table: "CourseTrainees");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_CourseTrainees_Trainees_TrineeID",
            //    table: "CourseTrainees");

            //migrationBuilder.RenameColumn(
            //    name: "TrineeID",
            //    table: "CourseTrainees",
            //    newName: "TraineeID");

            //migrationBuilder.RenameColumn(
            //    name: "CoruseID",
            //    table: "CourseTrainees",
            //    newName: "CourseID");

            //migrationBuilder.RenameIndex(
            //    name: "IX_CourseTrainees_TrineeID",
            //    table: "CourseTrainees",
            //    newName: "IX_CourseTrainees_TraineeID");

            //migrationBuilder.RenameIndex(
            //    name: "IX_CourseTrainees_CoruseID",
            //    table: "CourseTrainees",
            //    newName: "IX_CourseTrainees_CourseID");

            //migrationBuilder.AlterColumn<string>(
            //    name: "ImageUrl",
            //    table: "Trainees",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_CourseTrainees_Courses_CourseID",
            //    table: "CourseTrainees",
            //    column: "CourseID",
            //    principalTable: "Courses",
            //    principalColumn: "ID",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_CourseTrainees_Trainees_TraineeID",
            //    table: "CourseTrainees",
            //    column: "TraineeID",
            //    principalTable: "Trainees",
            //    principalColumn: "ID",
            //    onDelete: ReferentialAction.Cascade);
            migrationBuilder.DropTable(
            name: "CourseTrainees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTrainees_Courses_CourseID",
                table: "CourseTrainees");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTrainees_Trainees_TraineeID",
                table: "CourseTrainees");

            migrationBuilder.RenameColumn(
                name: "TraineeID",
                table: "CourseTrainees",
                newName: "TrineeID");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "CourseTrainees",
                newName: "CoruseID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTrainees_TraineeID",
                table: "CourseTrainees",
                newName: "IX_CourseTrainees_TrineeID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTrainees_CourseID",
                table: "CourseTrainees",
                newName: "IX_CourseTrainees_CoruseID");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTrainees_Courses_CoruseID",
                table: "CourseTrainees",
                column: "CoruseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTrainees_Trainees_TrineeID",
                table: "CourseTrainees",
                column: "TrineeID",
                principalTable: "Trainees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
