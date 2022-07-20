using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DataAccess.Migrations
{
    public partial class changedFieldsBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaysUntilEvent = table.Column<byte>(type: "tinyint", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    PercentageOfTotalMarks = table.Column<byte>(type: "tinyint", nullable: false),
                    NumberOfParticpants = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectsId = table.Column<int>(type: "int", nullable: false),
                    //CoverTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    //table.PrimaryKey("PK_SubjectDetails", x => x.Id);
                    //table.ForeignKey(
                    //    name: "FK_SubjectDetails_CoverTypes_CoverTypeId",
                    //    column: x => x.CoverTypeId,
                    //    principalTable: "CoverTypes",
                    //    principalColumn: "Id",
                    //    onDelete: ReferentialAction.Cascade);
                    //table.ForeignKey(
                    //    name: "FK_SubjectDetails_Subjects_SubjectsId",
                    //    column: x => x.SubjectsId,
                    //    principalTable: "Subjects",
                    //    principalColumn: "Id",
                    //    onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_SubjectDetails_CoverTypeId",
            //    table: "SubjectDetails",
            //    column: "CoverTypeId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SubjectDetails_SubjectsId",
            //    table: "SubjectDetails",
            //    column: "SubjectsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectDetails");
        }
    }
}
