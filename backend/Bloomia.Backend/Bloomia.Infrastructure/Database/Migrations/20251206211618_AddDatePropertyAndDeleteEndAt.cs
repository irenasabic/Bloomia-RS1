using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloomia.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddDatePropertyAndDeleteEndAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "TherapistAvailabilities");

            migrationBuilder.DropColumn(
                name: "EndAt",
                table: "TherapistAvailabilities");

            migrationBuilder.RenameColumn(
                name: "StartAt",
                table: "TherapistAvailabilities",
                newName: "StartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "TherapistAvailabilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TherapistAvailabilities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TherapistAvailabilities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAtUtc",
                table: "TherapistAvailabilities",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "TherapistAvailabilities");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "TherapistAvailabilities");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TherapistAvailabilities");

            migrationBuilder.DropColumn(
                name: "ModifiedAtUtc",
                table: "TherapistAvailabilities");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "TherapistAvailabilities",
                newName: "StartAt");

            migrationBuilder.AddColumn<string>(
                name: "DayOfWeek",
                table: "TherapistAvailabilities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "EndAt",
                table: "TherapistAvailabilities",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }
    }
}
