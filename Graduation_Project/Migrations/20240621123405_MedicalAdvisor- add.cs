using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graduation_Project.Migrations
{
    /// <inheritdoc />
    public partial class MedicalAdvisoradd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalAdvisor",
                table: "MedicalAdvisor");

            migrationBuilder.RenameTable(
                name: "MedicalAdvisor",
                newName: "medicalAdvisors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_medicalAdvisors",
                table: "medicalAdvisors",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_medicalAdvisors",
                table: "medicalAdvisors");

            migrationBuilder.RenameTable(
                name: "medicalAdvisors",
                newName: "MedicalAdvisor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalAdvisor",
                table: "MedicalAdvisor",
                column: "Id");
        }
    }
}
