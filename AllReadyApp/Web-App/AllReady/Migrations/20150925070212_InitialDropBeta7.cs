using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.SqlServer.Metadata;

namespace AllReady.Migrations
{
    public partial class InitialDropBeta7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostalCodeGeo",
                columns: table => new
                {
                    PostalCode = table.Column<string>(isNullable: false),
                    City = table.Column<string>(isNullable: true),
                    State = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCodeGeo", x => x.PostalCode);
                });
            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    CategoryTag = table.Column<string>(isNullable: true),
                    Description = table.Column<string>(isNullable: true),
                    MediaUrl = table.Column<string>(isNullable: true),
                    Name = table.Column<string>(isNullable: true),
                    PublishDateBegin = table.Column<DateTime>(isNullable: false),
                    PublishDateEnd = table.Column<DateTime>(isNullable: false),
                    ResourceUrl = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    LogoUrl = table.Column<string>(isNullable: true),
                    Name = table.Column<string>(isNullable: true),
                    WebUrl = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(isNullable: false),
                    ConcurrencyStamp = table.Column<string>(isNullable: true),
                    Name = table.Column<string>(isNullable: true),
                    NormalizedName = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    Address1 = table.Column<string>(isNullable: true),
                    Address2 = table.Column<string>(isNullable: true),
                    City = table.Column<string>(isNullable: true),
                    Country = table.Column<string>(isNullable: true),
                    Name = table.Column<string>(isNullable: true),
                    PhoneNumber = table.Column<string>(isNullable: true),
                    PostalCodePostalCode = table.Column<string>(isNullable: true),
                    State = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_PostalCodeGeo_PostalCodePostalCode",
                        column: x => x.PostalCodePostalCode,
                        principalTable: "PostalCodeGeo",
                        principalColumn: "PostalCode");
                });
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(isNullable: false),
                    AccessFailedCount = table.Column<int>(isNullable: false),
                    AssociatedTenantId = table.Column<int>(isNullable: true),
                    ConcurrencyStamp = table.Column<string>(isNullable: true),
                    Email = table.Column<string>(isNullable: true),
                    EmailConfirmed = table.Column<bool>(isNullable: false),
                    LockoutEnabled = table.Column<bool>(isNullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(isNullable: true),
                    NormalizedEmail = table.Column<string>(isNullable: true),
                    NormalizedUserName = table.Column<string>(isNullable: true),
                    PasswordHash = table.Column<string>(isNullable: true),
                    PhoneNumber = table.Column<string>(isNullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(isNullable: false),
                    SecurityStamp = table.Column<string>(isNullable: true),
                    TwoFactorEnabled = table.Column<bool>(isNullable: false),
                    UserName = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Tenant_AssociatedTenantId",
                        column: x => x.AssociatedTenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(isNullable: true),
                    ClaimValue = table.Column<string>(isNullable: true),
                    RoleId = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoleClaim<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    Description = table.Column<string>(isNullable: true),
                    EndDateTimeUtc = table.Column<DateTime>(isNullable: false),
                    ImageUrl = table.Column<string>(isNullable: true),
                    ManagingTenantId = table.Column<int>(isNullable: false),
                    Name = table.Column<string>(isNullable: false),
                    OrganizerId = table.Column<string>(isNullable: true),
                    StartDateTimeUtc = table.Column<DateTime>(isNullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaign_Tenant_ManagingTenantId",
                        column: x => x.ManagingTenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Campaign_ApplicationUser_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(isNullable: true),
                    ClaimValue = table.Column<string>(isNullable: true),
                    UserId = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(isNullable: false),
                    ProviderKey = table.Column<string>(isNullable: false),
                    ProviderDisplayName = table.Column<string>(isNullable: true),
                    UserId = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin<string>", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(isNullable: false),
                    RoleId = table.Column<string>(isNullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<string>", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    CampaignId = table.Column<int>(isNullable: false),
                    Description = table.Column<string>(isNullable: true),
                    EndDateTimeUtc = table.Column<DateTime>(isNullable: false),
                    ImageUrl = table.Column<string>(isNullable: true),
                    LocationId = table.Column<int>(isNullable: true),
                    Name = table.Column<string>(isNullable: true),
                    OrganizerId = table.Column<string>(isNullable: true),
                    StartDateTimeUtc = table.Column<DateTime>(isNullable: false),
                    TenantId = table.Column<int>(isNullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Activity_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Activity_ApplicationUser_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Activity_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "CampaignSponsors",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    CampaignId = table.Column<int>(isNullable: true),
                    TenantId = table.Column<int>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignSponsors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignSponsors_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CampaignSponsors_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "ActivitySignup",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    ActivityId = table.Column<int>(isNullable: true),
                    CheckinDateTime = table.Column<DateTime>(isNullable: true),
                    SignupDateTime = table.Column<DateTime>(isNullable: false),
                    UserId = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitySignup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivitySignup_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActivitySignup_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "AllReadyTask",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    ActivityId = table.Column<int>(isNullable: true),
                    Description = table.Column<string>(isNullable: true),
                    EndDateTimeUtc = table.Column<DateTime>(isNullable: true),
                    Name = table.Column<string>(isNullable: true),
                    StartDateTimeUtc = table.Column<DateTime>(isNullable: true),
                    TenantId = table.Column<int>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllReadyTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllReadyTask_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AllReadyTask_Tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenant",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "TaskUsers",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    Status = table.Column<string>(isNullable: true),
                    StatusDateTimeUtc = table.Column<DateTime>(isNullable: false),
                    StatusDescription = table.Column<string>(isNullable: true),
                    TaskId = table.Column<int>(isNullable: true),
                    UserId = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskUsers_AllReadyTask_TaskId",
                        column: x => x.TaskId,
                        principalTable: "AllReadyTask",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskUsers_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");
            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName");
            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("ActivitySignup");
            migrationBuilder.DropTable("CampaignSponsors");
            migrationBuilder.DropTable("Resource");
            migrationBuilder.DropTable("TaskUsers");
            migrationBuilder.DropTable("AspNetRoleClaims");
            migrationBuilder.DropTable("AspNetUserClaims");
            migrationBuilder.DropTable("AspNetUserLogins");
            migrationBuilder.DropTable("AspNetUserRoles");
            migrationBuilder.DropTable("AllReadyTask");
            migrationBuilder.DropTable("AspNetRoles");
            migrationBuilder.DropTable("Activity");
            migrationBuilder.DropTable("Campaign");
            migrationBuilder.DropTable("Location");
            migrationBuilder.DropTable("AspNetUsers");
            migrationBuilder.DropTable("PostalCodeGeo");
            migrationBuilder.DropTable("Tenant");
        }
    }
}
