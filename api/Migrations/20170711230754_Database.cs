using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "arena",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(maxLength: 100, nullable: false),
                    latitude = table.Column<string>(maxLength: 30, nullable: true),
                    longitude = table.Column<string>(maxLength: 30, nullable: true),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arena", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    birthday = table.Column<DateTime>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    firstName = table.Column<string>(maxLength: 100, nullable: false),
                    lastName = table.Column<string>(maxLength: 100, nullable: true),
                    nickname = table.Column<string>(maxLength: 100, nullable: true),
                    number = table.Column<byte>(nullable: true),
                    password = table.Column<string>(maxLength: 100, nullable: false),
                    position = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pelada",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    arenaDefaultId = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    createdByUserId = table.Column<int>(nullable: false),
                    day = table.Column<string>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pelada", x => x.id);
                    table.ForeignKey(
                        name: "ForeignKey_Pelada_ArenaDefaultId",
                        column: x => x.arenaDefaultId,
                        principalTable: "arena",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ForeignKey_Pelada_UserId",
                        column: x => x.createdByUserId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "peladaEvent",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    arenaId = table.Column<int>(nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    peladaId = table.Column<int>(nullable: false),
                    quantityOfUsers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peladaEvent", x => x.id);
                    table.ForeignKey(
                        name: "ForeignKey_PeladaEvent_ArenaId",
                        column: x => x.arenaId,
                        principalTable: "arena",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ForeignKey_PeladaEvent_PeladaId",
                        column: x => x.peladaId,
                        principalTable: "pelada",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "peladaTeam",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    peladaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peladaTeam", x => x.id);
                    table.ForeignKey(
                        name: "ForeignKey_PeladaTeam_PeladaId",
                        column: x => x.peladaId,
                        principalTable: "pelada",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "peladaUser",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    isAdministrator = table.Column<bool>(nullable: false, defaultValue: false),
                    isMonthly = table.Column<bool>(nullable: false, defaultValue: false),
                    peladaId = table.Column<int>(nullable: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peladaUser", x => x.id);
                    table.UniqueConstraint("AK_peladaUser_peladaId_userId", x => new { x.peladaId, x.userId });
                    table.ForeignKey(
                        name: "ForeignKey_PeladaUser_PeladaId",
                        column: x => x.peladaId,
                        principalTable: "pelada",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ForeignKey_PeladaUser_UserId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "peladaEventUser",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    peladaEventId = table.Column<int>(nullable: false),
                    userConfirmed = table.Column<bool>(nullable: false, defaultValue: false),
                    userId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peladaEventUser", x => x.id);
                    table.ForeignKey(
                        name: "ForeignKey_PeladaEventUser_PeladaEventoId",
                        column: x => x.peladaEventId,
                        principalTable: "peladaEvent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ForeignKey_PeladaEventUser_UserId",
                        column: x => x.userId,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pelada_arenaDefaultId",
                table: "pelada",
                column: "arenaDefaultId");

            migrationBuilder.CreateIndex(
                name: "IX_pelada_createdByUserId",
                table: "pelada",
                column: "createdByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_peladaEvent_arenaId",
                table: "peladaEvent",
                column: "arenaId");

            migrationBuilder.CreateIndex(
                name: "IX_peladaEvent_peladaId",
                table: "peladaEvent",
                column: "peladaId");

            migrationBuilder.CreateIndex(
                name: "IX_peladaEventUser_peladaEventId",
                table: "peladaEventUser",
                column: "peladaEventId");

            migrationBuilder.CreateIndex(
                name: "IX_peladaEventUser_userId",
                table: "peladaEventUser",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_peladaTeam_peladaId",
                table: "peladaTeam",
                column: "peladaId");

            migrationBuilder.CreateIndex(
                name: "IX_peladaUser_userId",
                table: "peladaUser",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "peladaEventUser");

            migrationBuilder.DropTable(
                name: "peladaTeam");

            migrationBuilder.DropTable(
                name: "peladaUser");

            migrationBuilder.DropTable(
                name: "peladaEvent");

            migrationBuilder.DropTable(
                name: "pelada");

            migrationBuilder.DropTable(
                name: "arena");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
