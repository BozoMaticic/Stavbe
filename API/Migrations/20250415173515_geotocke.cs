using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class geotocke : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeoTocke",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SifraObjekta = table.Column<string>(type: "TEXT", nullable: false),
                    SifraMerilnegaMesta = table.Column<string>(type: "TEXT", nullable: true),
                    Zaporedje = table.Column<int>(type: "INTEGER", nullable: true),
                    Lat = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    Lng = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    JavniObjektSifraJavnegaObjekta = table.Column<string>(type: "TEXT", nullable: true),
                    FID = table.Column<int>(type: "INTEGER", nullable: true),
                    OZN_obj = table.Column<string>(type: "TEXT", nullable: true),
                    Naziv = table.Column<string>(type: "TEXT", nullable: true),
                    SID = table.Column<string>(type: "TEXT", nullable: true),
                    SIFKO = table.Column<string>(type: "TEXT", nullable: true),
                    ST_stevilka = table.Column<string>(type: "TEXT", nullable: true),
                    Ozn_tock = table.Column<string>(type: "TEXT", nullable: true),
                    DDLat = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    DDLon = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    IdJavnegaObjekta = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoTocke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeoTocke_Stavbe_IdJavnegaObjekta",
                        column: x => x.IdJavnegaObjekta,
                        principalTable: "Stavbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeoTocke_IdJavnegaObjekta",
                table: "GeoTocke",
                column: "IdJavnegaObjekta");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeoTocke");
        }
    }
}
