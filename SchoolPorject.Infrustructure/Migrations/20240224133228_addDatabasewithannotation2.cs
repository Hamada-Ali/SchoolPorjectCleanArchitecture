using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrustructure.Migrations
{
    public partial class addDatabasewithannotation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_departments_DID",
                table: "Instructor");

            migrationBuilder.AlterColumn<int>(
                name: "SupervisorId",
                table: "Instructor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DID",
                table: "Instructor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_departments_DID",
                table: "Instructor",
                column: "DID",
                principalTable: "departments",
                principalColumn: "DID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_departments_DID",
                table: "Instructor");

            migrationBuilder.AlterColumn<int>(
                name: "SupervisorId",
                table: "Instructor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DID",
                table: "Instructor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_departments_DID",
                table: "Instructor",
                column: "DID",
                principalTable: "departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
