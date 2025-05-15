using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class mojElektro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MojElektroMerilnaMesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnotniIdentifikator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SifraJavnegaObjekta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NazivJavnegaObjekta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GsrnMM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SNizvod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NNizvod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dobavitelj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdJavnegaObjekta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MojElektroMerilnaMesta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MojElektroMerilnaMesta_Stavbe_IdJavnegaObjekta",
                        column: x => x.IdJavnegaObjekta,
                        principalTable: "Stavbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MojElektro15MinMeritve",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StMerilnegaMesta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMerilnegaMesta = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Leto = table.Column<int>(type: "int", nullable: false),
                    Mesec = table.Column<int>(type: "int", nullable: false),
                    LetoMesec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LetoMesecBlok = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LetoTedenDan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LetoTedenDanUra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LetoDanUra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Energija_A_plus = table.Column<decimal>(type: "decimal(7,4)", nullable: false),
                    Energija_A_minus = table.Column<decimal>(type: "decimal(7,4)", nullable: false),
                    Energija_R_plus = table.Column<decimal>(type: "decimal(7,4)", nullable: false),
                    Energija_R_minus = table.Column<decimal>(type: "decimal(7,4)", nullable: false),
                    PrejetaDelovnaMoc = table.Column<decimal>(type: "decimal(7,4)", nullable: false),
                    OddanaDelovnaMoc = table.Column<decimal>(type: "decimal(7,4)", nullable: false),
                    PrejetaJalovaMoc = table.Column<decimal>(type: "decimal(7,4)", nullable: false),
                    OddanaJalovaMoc = table.Column<decimal>(type: "decimal(7,4)", nullable: false),
                    Blok = table.Column<int>(type: "int", nullable: false),
                    IdMerilnegaMestaMojElektro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MojElektro15MinMeritve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MojElektro15MinMeritve_MojElektroMerilnaMesta_IdMerilnegaMestaMojElektro",
                        column: x => x.IdMerilnegaMestaMojElektro,
                        principalTable: "MojElektroMerilnaMesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MojElektro15MinMeritve_IdMerilnegaMestaMojElektro",
                table: "MojElektro15MinMeritve",
                column: "IdMerilnegaMestaMojElektro");

            migrationBuilder.CreateIndex(
                name: "IX_MojElektroMerilnaMesta_IdJavnegaObjekta",
                table: "MojElektroMerilnaMesta",
                column: "IdJavnegaObjekta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MojElektro15MinMeritve");

            migrationBuilder.DropTable(
                name: "MojElektroMerilnaMesta");
        }
    }
}
