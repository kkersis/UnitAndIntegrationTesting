using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Testavimas_1.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Darbuotojai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vardas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miestas = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Darbuotojai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skambuciai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Atsiliepta = table.Column<bool>(type: "bit", nullable: false),
                    Laikas = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DarbuotojasId = table.Column<int>(type: "int", nullable: false),
                    Trukme = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skambuciai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skambuciai_Darbuotojai_DarbuotojasId",
                        column: x => x.DarbuotojasId,
                        principalTable: "Darbuotojai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skambuciai_DarbuotojasId",
                table: "Skambuciai",
                column: "DarbuotojasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skambuciai");

            migrationBuilder.DropTable(
                name: "Darbuotojai");
        }
    }
}
