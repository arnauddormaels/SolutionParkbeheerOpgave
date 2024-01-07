using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkDataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ToevoegenEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HuurperiodeEF",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EindDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aantaldagen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuurperiodeEF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parken",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Locatie = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Huizen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Straat = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Nr = table.Column<int>(type: "int", nullable: false),
                    Actief = table.Column<bool>(type: "bit", nullable: false),
                    ParkId = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huizen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Huizen_Parken_ParkId",
                        column: x => x.ParkId,
                        principalTable: "Parken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HuurContracten",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    HuurperiodeId = table.Column<int>(type: "int", nullable: false),
                    HuurderId = table.Column<int>(type: "int", nullable: false),
                    HuisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuurContracten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HuurContracten_Huizen_HuisId",
                        column: x => x.HuisId,
                        principalTable: "Huizen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HuurContracten_Huurders_HuurderId",
                        column: x => x.HuurderId,
                        principalTable: "Huurders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HuurContracten_HuurperiodeEF_HuurperiodeId",
                        column: x => x.HuurperiodeId,
                        principalTable: "HuurperiodeEF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Huizen_ParkId",
                table: "Huizen",
                column: "ParkId");

            migrationBuilder.CreateIndex(
                name: "IX_HuurContracten_HuisId",
                table: "HuurContracten",
                column: "HuisId");

            migrationBuilder.CreateIndex(
                name: "IX_HuurContracten_HuurderId",
                table: "HuurContracten",
                column: "HuurderId");

            migrationBuilder.CreateIndex(
                name: "IX_HuurContracten_HuurperiodeId",
                table: "HuurContracten",
                column: "HuurperiodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HuurContracten");

            migrationBuilder.DropTable(
                name: "Huizen");

            migrationBuilder.DropTable(
                name: "HuurperiodeEF");

            migrationBuilder.DropTable(
                name: "Parken");
        }
    }
}
