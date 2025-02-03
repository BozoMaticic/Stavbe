using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Prva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stavbe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SifraJavnegaObjekta = table.Column<string>(type: "TEXT", nullable: false),
                    Naziv = table.Column<string>(type: "TEXT", nullable: false),
                    NazivEnote = table.Column<string>(type: "TEXT", nullable: true),
                    Naslov = table.Column<string>(type: "TEXT", nullable: true),
                    UlicaHs = table.Column<string>(type: "TEXT", nullable: true),
                    KatastrskaObcinaSifra = table.Column<string>(type: "TEXT", nullable: true),
                    KatastrskaObcinaIme = table.Column<string>(type: "TEXT", nullable: true),
                    ST_OBJ_Gurs = table.Column<string>(type: "TEXT", nullable: true),
                    NTP_NetoTloris = table.Column<decimal>(type: "decimal(7,2)", nullable: true),
                    UporabnaPovrsina = table.Column<decimal>(type: "decimal(7,2)", nullable: true),
                    ProjekcijaTloris = table.Column<decimal>(type: "decimal(7,2)", nullable: true),
                    VrstaObjekta = table.Column<string>(type: "TEXT", nullable: false),
                    VrstaObjektaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Ogrevanje = table.Column<string>(type: "TEXT", nullable: true),
                    OgrevanjeId = table.Column<int>(type: "INTEGER", nullable: true),
                    OgrevanjeOznaka = table.Column<string>(type: "TEXT", nullable: true),
                    OgrevanjeDrugi = table.Column<string>(type: "TEXT", nullable: true),
                    Opomba = table.Column<string>(type: "TEXT", nullable: true),
                    Parcele = table.Column<string>(type: "TEXT", nullable: true),
                    ParcelePovrsina = table.Column<decimal>(type: "decimal(7,2)", nullable: true),
                    StavbaDaNe = table.Column<bool>(type: "INTEGER", nullable: true),
                    StavbaStevilka = table.Column<string>(type: "TEXT", nullable: true),
                    StavbaDel = table.Column<string>(type: "TEXT", nullable: true),
                    KlasifikacijaCcSi = table.Column<string>(type: "TEXT", nullable: true),
                    KlasifikacijaNaziv = table.Column<string>(type: "TEXT", nullable: true),
                    KondicioniranaPovrsina = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    PovrsinaAplikacija = table.Column<decimal>(type: "decimal(7,2)", nullable: true),
                    LetoIzgradnje = table.Column<string>(type: "TEXT", nullable: true),
                    LetoObnove = table.Column<string>(type: "TEXT", nullable: true),
                    KlimatskiKraj = table.Column<string>(type: "TEXT", nullable: true),
                    ZemljepisnaSirina = table.Column<decimal>(type: "decimal(7,4)", nullable: true),
                    ZemljepisnaDolzina = table.Column<decimal>(type: "decimal(7,4)", nullable: true),
                    NadmorskaVisina = table.Column<decimal>(type: "decimal(7,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stavbe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    KnownAs = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastActive = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Introduction = table.Column<string>(type: "TEXT", nullable: true),
                    Interests = table.Column<string>(type: "TEXT", nullable: true),
                    LookingFor = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MerilnaMesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StMerilnegaMesta = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Energent = table.Column<int>(type: "INTEGER", nullable: false),
                    EnergentTip = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: true),
                    Ogrevanje = table.Column<string>(type: "TEXT", nullable: true),
                    OgrevanjeId = table.Column<int>(type: "INTEGER", nullable: true),
                    OgrevanjeOznaka = table.Column<string>(type: "TEXT", nullable: true),
                    IdJavnegaZavoda = table.Column<int>(type: "INTEGER", nullable: false),
                    SifraJavnegaObjekta = table.Column<string>(type: "TEXT", nullable: false),
                    NazivJavnegaObjekta = table.Column<string>(type: "TEXT", nullable: false),
                    NickName = table.Column<string>(type: "TEXT", nullable: true),
                    Dobavitelj = table.Column<string>(type: "TEXT", nullable: false),
                    DobaviteljNaziv = table.Column<string>(type: "TEXT", nullable: true),
                    ObracunskaMoc = table.Column<int>(type: "INTEGER", nullable: false),
                    ZemljepisnaSirina = table.Column<decimal>(type: "decimal(7,4)", nullable: true),
                    ZemljepisnaDolzina = table.Column<decimal>(type: "decimal(7,4)", nullable: true),
                    NadmorskaVisina = table.Column<decimal>(type: "decimal(7,4)", nullable: true),
                    IdStavbe = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerilnaMesta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerilnaMesta_Stavbe_IdStavbe",
                        column: x => x.IdStavbe,
                        principalTable: "Stavbe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    PublicId = table.Column<string>(type: "TEXT", nullable: true),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Odcitki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IdJavnegaObjekta = table.Column<int>(type: "INTEGER", nullable: false),
                    StMerilnegaMesta = table.Column<string>(type: "TEXT", nullable: false),
                    NazivMerilnegaMesta = table.Column<string>(type: "TEXT", nullable: false),
                    EnergentTip = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: true),
                    TipOgrevanja = table.Column<string>(type: "TEXT", nullable: true),
                    TipOgrevanjaOznaka = table.Column<string>(type: "TEXT", nullable: true),
                    StevilkaRacuna = table.Column<string>(type: "TEXT", nullable: true),
                    DatumOdcitka = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ObdobjeStoritveOd = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ObdobjeStoritveDo = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LetoMesec = table.Column<string>(type: "TEXT", nullable: false),
                    Energija = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    Znesek = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    EleenergijaVt = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    EleenergijaMt = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    EleenergijaET = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    EleobracunskaMoc = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    EleJalovaEnergija = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    ELEEnergijaEUR = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    ELEOmreznina = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    ELEPrispevki = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    PLINPorabaKWh = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    PLINOdjemnaMoc = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    PLINSkupajBruto = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    PLINZemeljskiPlin = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    PLINDistribucija = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    PLINPrispevki = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    DOObracunskaMocEuro = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    DOEnergijaEuro = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    ElkoLbUnpEnotaMere = table.Column<string>(type: "TEXT", nullable: true),
                    ElkoLbUnpKolicina = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    ElkoLbUnpEnergijskiEkvivalent = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    VODAPorabaM3 = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    VODAVodarinaEur = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    VODAPrispevekEur = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    VODAOmrezninaEur = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    VODAZnesek = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    KANALKanalscinaEur = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    KANALOmrezninaEur = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    KANALCiscenjeVodeEur = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    KANALCCNOmrezninaEur = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    KANALZnesek = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    SMETIPapirKartonEur = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    SMETIEmbalazaEur = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    SMETIZbiranjeBioEur = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    SMETIObdelavaBioEur = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    SMETIZbiranjeMKOEur = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    SMETIObdelavaMKOEur = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    SMETIOdlaganjeMKOEur = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    SMETIZnesek = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    SMETIOpomba = table.Column<string>(type: "TEXT", nullable: true),
                    IdMerilnegaMesta = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odcitki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odcitki_MerilnaMesta_IdMerilnegaMesta",
                        column: x => x.IdMerilnegaMesta,
                        principalTable: "MerilnaMesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MerilnaMesta_IdStavbe",
                table: "MerilnaMesta",
                column: "IdStavbe");

            migrationBuilder.CreateIndex(
                name: "IX_Odcitki_EnergentTip",
                table: "Odcitki",
                column: "EnergentTip");

            migrationBuilder.CreateIndex(
                name: "IX_Odcitki_IdJavnegaObjekta",
                table: "Odcitki",
                column: "IdJavnegaObjekta");

            migrationBuilder.CreateIndex(
                name: "IX_Odcitki_IdMerilnegaMesta",
                table: "Odcitki",
                column: "IdMerilnegaMesta");

            migrationBuilder.CreateIndex(
                name: "IX_Odcitki_LetoMesec",
                table: "Odcitki",
                column: "LetoMesec");

            migrationBuilder.CreateIndex(
                name: "IX_Odcitki_StMerilnegaMesta",
                table: "Odcitki",
                column: "StMerilnegaMesta");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AppUserId",
                table: "Photos",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Odcitki");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "MerilnaMesta");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Stavbe");
        }
    }
}
