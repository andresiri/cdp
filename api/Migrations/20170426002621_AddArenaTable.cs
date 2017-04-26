using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class AddArenaTable : Migration
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
                    createdAt = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    firstName = table.Column<string>(maxLength: 100, nullable: false),
                    lastName = table.Column<string>(maxLength: 100, nullable: true),
                    nickname = table.Column<string>(maxLength: 100, nullable: true),
                    number = table.Column<byte>(nullable: true),
                    password = table.Column<string>(maxLength: 100, nullable: false),
                    position = table.Column<int>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "arena");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
