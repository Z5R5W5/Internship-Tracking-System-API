using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Internship.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class Fashgh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_applications_Student_StudentId",
                table: "applications");

            migrationBuilder.DropForeignKey(
                name: "FK_evaluations_supervisors_SupervisorId",
                table: "evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_internshipOffers_companies_CompanyId",
                table: "internshipOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_reports_Student_StudentId",
                table: "reports");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "supervisors");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "reports",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "internshipOffers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SupervisorId",
                table: "evaluations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "evaluations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AcceptedInternshipId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Major",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniversityId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "applications",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_evaluations_StudentId",
                table: "evaluations",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_applications_AspNetUsers_StudentId",
                table: "applications",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_evaluations_AspNetUsers_StudentId",
                table: "evaluations",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_evaluations_AspNetUsers_SupervisorId",
                table: "evaluations",
                column: "SupervisorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_internshipOffers_AspNetUsers_CompanyId",
                table: "internshipOffers",
                column: "CompanyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reports_AspNetUsers_StudentId",
                table: "reports",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_applications_AspNetUsers_StudentId",
                table: "applications");

            migrationBuilder.DropForeignKey(
                name: "FK_evaluations_AspNetUsers_StudentId",
                table: "evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_evaluations_AspNetUsers_SupervisorId",
                table: "evaluations");

            migrationBuilder.DropForeignKey(
                name: "FK_internshipOffers_AspNetUsers_CompanyId",
                table: "internshipOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_reports_AspNetUsers_StudentId",
                table: "reports");

            migrationBuilder.DropIndex(
                name: "IX_evaluations_StudentId",
                table: "evaluations");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "evaluations");

            migrationBuilder.DropColumn(
                name: "AcceptedInternshipId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Major",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "reports",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "internshipOffers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "SupervisorId",
                table: "evaluations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "applications",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcceptedInternshipId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniversityId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_internshipOffers_AcceptedInternshipId",
                        column: x => x.AcceptedInternshipId,
                        principalTable: "internshipOffers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "supervisors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternshipOfferId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Academic")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supervisors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_supervisors_internshipOffers_InternshipOfferId",
                        column: x => x.InternshipOfferId,
                        principalTable: "internshipOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_AcceptedInternshipId",
                table: "Student",
                column: "AcceptedInternshipId");

            migrationBuilder.CreateIndex(
                name: "IX_supervisors_InternshipOfferId",
                table: "supervisors",
                column: "InternshipOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_applications_Student_StudentId",
                table: "applications",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_evaluations_supervisors_SupervisorId",
                table: "evaluations",
                column: "SupervisorId",
                principalTable: "supervisors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_internshipOffers_companies_CompanyId",
                table: "internshipOffers",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reports_Student_StudentId",
                table: "reports",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
