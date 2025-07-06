using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class add_relation_doctorandtreatment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Doctors_DoctorId",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_DoctorId",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Treatments");

            migrationBuilder.AddColumn<int>(
                name: "TreatmentId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_TreatmentId",
                table: "Doctors",
                column: "TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Treatments_TreatmentId",
                table: "Doctors",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "TreatmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Treatments_TreatmentId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_TreatmentId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "TreatmentId",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Treatments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_DoctorId",
                table: "Treatments",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Doctors_DoctorId",
                table: "Treatments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "ID");
        }
    }
}
