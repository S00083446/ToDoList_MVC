using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DataAccess.Migrations
{
    public partial class removedCoverTypeClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_SubjectDetails_CoverTypes_CoverTypeId",
            //    table: "SubjectDetails");

            //migrationBuilder.DropTable(
            //    name: "CoverTypes");

            //migrationBuilder.DropIndex(
            //    name: "IX_SubjectDetails_CoverTypeId",
            //    table: "SubjectDetails");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Subjects");

            //migrationBuilder.DropColumn(
            //    name: "CoverTypeId",
            //    table: "SubjectDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CoverTypeId",
                table: "SubjectDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CoverTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectDetails_CoverTypeId",
                table: "SubjectDetails",
                column: "CoverTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectDetails_CoverTypes_CoverTypeId",
                table: "SubjectDetails",
                column: "CoverTypeId",
                principalTable: "CoverTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
