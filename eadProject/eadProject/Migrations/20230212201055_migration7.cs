using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eadProject.Migrations
{
    /// <inheritdoc />
    public partial class migration7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reports_PatientId",
                table: "Reports",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Patients_PatientId",
                table: "Reports",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Patients_PatientId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_PatientId",
                table: "Reports");
        }
    }
}
