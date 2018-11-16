using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreFramework.Infrastructure.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_course",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Credits = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_course", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_student",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(nullable: true),
                    FirstMidName = table.Column<string>(nullable: true),
                    EnrollmentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_student", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseID = table.Column<int>(nullable: false),
                    StudentID = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_enrollment", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_tbl_enrollment_tbl_course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "tbl_course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_enrollment_tbl_student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "tbl_student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_enrollment_CourseID",
                table: "tbl_enrollment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_enrollment_StudentID",
                table: "tbl_enrollment",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_enrollment");

            migrationBuilder.DropTable(
                name: "tbl_course");

            migrationBuilder.DropTable(
                name: "tbl_student");
        }
    }
}
