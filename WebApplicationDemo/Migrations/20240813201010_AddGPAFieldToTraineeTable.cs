using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddGPAFieldToTraineeTable : Migration
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
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GPA",
                table: "Trainees",
                type: "float",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Departments_DeptID",
                table: "Trainees",
                column: "DeptID",
                principalTable: "Departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Departments_DeptID",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "GPA",
                table: "Trainees");

            migrationBuilder.AlterColumn<int>(
                name: "DeptID",
                table: "Trainees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Departments_DeptID",
                table: "Trainees",
                column: "DeptID",
                principalTable: "Departments",
                principalColumn: "ID");
        }
    }
}
