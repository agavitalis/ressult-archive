using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResultArchive.Migrations
{
    public partial class LogsTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditExamLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamLogId = table.Column<int>(nullable: false),
                    SN = table.Column<string>(nullable: true),
                    Jamb_No = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Refrence_Text = table.Column<string>(nullable: true),
                    Refrence_Image = table.Column<string>(nullable: true),
                    Question = table.Column<string>(nullable: true),
                    Option_A = table.Column<string>(nullable: true),
                    Option_B = table.Column<string>(nullable: true),
                    Option_C = table.Column<string>(nullable: true),
                    Option_D = table.Column<string>(nullable: true),
                    Option_E = table.Column<string>(nullable: true),
                    Answer_Choice = table.Column<string>(nullable: true),
                    Answer_Point = table.Column<string>(nullable: true),
                    Option_A_Choice = table.Column<string>(nullable: true),
                    Option_B_Choice = table.Column<string>(nullable: true),
                    Option_C_Choice = table.Column<string>(nullable: true),
                    Option_D_Choice = table.Column<string>(nullable: true),
                    Option_E_Choice = table.Column<string>(nullable: true),
                    Is_Bonus = table.Column<string>(nullable: true),
                    Is_Option_Image = table.Column<string>(nullable: true),
                    Ans_From_Student = table.Column<string>(nullable: true),
                    Question_No = table.Column<string>(nullable: true),
                    Question_Batch_No = table.Column<string>(nullable: true),
                    CourseCode = table.Column<string>(nullable: true),
                    RegNumber = table.Column<string>(nullable: true),
                    School = table.Column<string>(nullable: true),
                    School_Acronym = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Session = table.Column<string>(nullable: true),
                    Semester = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    PerformedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditExamLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResultId = table.Column<int>(nullable: false),
                    RegNumber = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    OtherName = table.Column<string>(nullable: true),
                    CourseCode = table.Column<string>(nullable: true),
                    CVScore = table.Column<string>(nullable: true),
                    ExamScore = table.Column<string>(nullable: true),
                    TotalScore = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    SchoolId = table.Column<int>(nullable: false),
                    SessionId = table.Column<int>(nullable: false),
                    Semester = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    PerformedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditSessions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    PerformedBy = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditSessions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditExamLogs");

            migrationBuilder.DropTable(
                name: "AuditResults");

            migrationBuilder.DropTable(
                name: "AuditSessions");
        }
    }
}
