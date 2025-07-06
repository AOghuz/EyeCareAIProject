using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class add_blogandtreatment_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TurkishIdentityNumber",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "BlogName",
                table: "Blogs",
                newName: "Title");

            migrationBuilder.AddColumn<DateTime>(
                name: "BlogDate",
                table: "Blogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LittleDesc",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TreatmentId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_TreatmentId",
                table: "Blogs",
                column: "TreatmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Treatments_TreatmentId",
                table: "Blogs",
                column: "TreatmentId",
                principalTable: "Treatments",
                principalColumn: "TreatmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Treatments_TreatmentId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_TreatmentId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogDate",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "LittleDesc",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "TreatmentId",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Blogs",
                newName: "BlogName");

            migrationBuilder.AddColumn<long>(
                name: "TurkishIdentityNumber",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true);
        }
    }
}
