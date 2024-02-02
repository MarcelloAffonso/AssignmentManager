using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssignmentManager.Migrations
{
    public partial class CorrectingNotesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_Assignments_AssignmentId",
                table: "Note");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Note",
                table: "Note");

            migrationBuilder.RenameTable(
                name: "Note",
                newName: "Notes");

            migrationBuilder.RenameIndex(
                name: "IX_Note_AssignmentId",
                table: "Notes",
                newName: "IX_Notes_AssignmentId");

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Assignments_AssignmentId",
                table: "Notes",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "AssignmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Assignments_AssignmentId",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "Note");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_AssignmentId",
                table: "Note",
                newName: "IX_Note_AssignmentId");

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "Note",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Note",
                table: "Note",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Assignments_AssignmentId",
                table: "Note",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "AssignmentId");
        }
    }
}
