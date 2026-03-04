using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_management_Project.Migrations
{
    /// <inheritdoc />
    public partial class InitialEventManagementBaseline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAuthDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEndUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FailedLoginCount = table.Column<int>(type: "int", nullable: false),
                    RefreshTokenHash = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    RefreshTokenExpiryUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RefreshTokenCreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuthDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    StartUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    OrganizerId = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_UserAuthDetails_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "UserAuthDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    UserDetailId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.UserDetailId);
                    table.ForeignKey(
                        name: "FK_UserDetails_UserAuthDetails_UserDetailId",
                        column: x => x.UserDetailId,
                        principalTable: "UserAuthDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventRegistrations",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RegisteredUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationStatus = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    WaitlistPosition = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRegistrations", x => new { x.EventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_EventRegistrations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventRegistrations_UserAuthDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "UserAuthDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_EventId_RegistrationStatus_WaitlistPosition",
                table: "EventRegistrations",
                columns: new[] { "EventId", "RegistrationStatus", "WaitlistPosition" });

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_UserId_RegisteredUtc",
                table: "EventRegistrations",
                columns: new[] { "UserId", "RegisteredUtc" });

            migrationBuilder.CreateIndex(
                name: "IX_Events_OrganizerId_StartUtc",
                table: "Events",
                columns: new[] { "OrganizerId", "StartUtc" });

            migrationBuilder.CreateIndex(
                name: "IX_Events_StartUtc",
                table: "Events",
                column: "StartUtc");

            migrationBuilder.CreateIndex(
                name: "IX_Events_Status_StartUtc",
                table: "Events",
                columns: new[] { "Status", "StartUtc" });

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthDetails_Email",
                table: "UserAuthDetails",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthDetails_Username",
                table: "UserAuthDetails",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventRegistrations");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "UserAuthDetails");
        }
    }
}
