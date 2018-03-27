using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace project3data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    areas = table.Column<string>(nullable: true),
                    latitude = table.Column<decimal>(nullable: true),
                    longitude = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BicycleCrimes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    caseNumber = table.Column<string>(nullable: true),
                    districtid = table.Column<int>(nullable: true),
                    crimeTime = table.Column<TimeSpan>(nullable: false),
                    registerDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BicycleCrimes", x => x.id);
                    table.ForeignKey(
                        name: "FK_BicycleCrimes_Districts_districtid",
                        column: x => x.districtid,
                        principalTable: "Districts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StreetCrimes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    caseNumber = table.Column<string>(nullable: true),
                    districtid = table.Column<int>(nullable: true),
                    crimeTime = table.Column<TimeSpan>(nullable: false),
                    registerDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreetCrimes", x => x.id);
                    table.ForeignKey(
                        name: "FK_StreetCrimes_Districts_districtid",
                        column: x => x.districtid,
                        principalTable: "Districts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BicycleCrimes_districtid",
                table: "BicycleCrimes",
                column: "districtid");

            migrationBuilder.CreateIndex(
                name: "IX_StreetCrimes_districtid",
                table: "StreetCrimes",
                column: "districtid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BicycleCrimes");

            migrationBuilder.DropTable(
                name: "StreetCrimes");

            migrationBuilder.DropTable(
                name: "Districts");
        }
    }
}
