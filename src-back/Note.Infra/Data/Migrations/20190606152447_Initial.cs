using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Note.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(maxLength: 250, nullable: true),
                    LastName = table.Column<string>(maxLength: 250, nullable: true),
                    Email = table.Column<string>(maxLength: 250, nullable: true),
                    Roles = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Slug = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    OwnerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spaces_AppUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    Title = table.Column<string>(maxLength: 250, nullable: false),
                    Slug = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    SpaceId = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_AppUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Pages_Spaces_SpaceId",
                        column: x => x.SpaceId,
                        principalTable: "Spaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "FirstName", "LastName", "Password", "Roles", "Salt", "UpdatedAt", "UpdatedBy", "UserName" },
                values: new object[] { new Guid("7e8b0c60-9419-452e-9fac-0ec52e6f90fe"), new DateTime(2019, 6, 6, 17, 24, 46, 379, DateTimeKind.Local).AddTicks(975), "Seed", "admin@note.com", null, null, "$2b$10$eTogdRTbhMqLHGO5m4vFxuNybkE8cNURSgvd/Ni1GvhSEMVXH5fJK", "APP_ADMIN,APP_USER", "Dat1vPnOX9AZG+9bu57SSg==", null, null, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_UserName",
                table: "AppUsers",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pages_OwnerId",
                table: "Pages",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_Slug",
                table: "Pages",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pages_SpaceId",
                table: "Pages",
                column: "SpaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Spaces_OwnerId",
                table: "Spaces",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Spaces_Slug",
                table: "Spaces",
                column: "Slug",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Spaces");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
