using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_management_Project.Migrations
{
    /// <inheritdoc />
    public partial class RemoveWaitlistField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EventRegistrations_EventId_RegistrationStatus_WaitlistPosition",
                table: "EventRegistrations");

            migrationBuilder.DropColumn(
                name: "FailedLoginCount",
                table: "UserAuthDetails");

            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "UserAuthDetails");

            migrationBuilder.DropColumn(
                name: "LockoutEndUtc",
                table: "UserAuthDetails");

            migrationBuilder.DropColumn(
                name: "WaitlistPosition",
                table: "EventRegistrations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FailedLoginCount",
                table: "UserAuthDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "UserAuthDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LockoutEndUtc",
                table: "UserAuthDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WaitlistPosition",
                table: "EventRegistrations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_EventId_RegistrationStatus_WaitlistPosition",
                table: "EventRegistrations",
                columns: new[] { "EventId", "RegistrationStatus", "WaitlistPosition" });
        }
    }
}
