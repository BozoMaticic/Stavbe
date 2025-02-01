﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250131082857_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Interests")
                        .HasColumnType("TEXT");

                    b.Property<string>("Introduction")
                        .HasColumnType("TEXT");

                    b.Property<string>("KnownAs")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("TEXT");

                    b.Property<string>("LookingFor")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Entities.MerilnoMesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Dobavitelj")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DobaviteljNaziv")
                        .HasColumnType("TEXT");

                    b.Property<int>("Energent")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EnergentTip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("IdJavnegaZavoda")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdStavbe")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("NadmorskaVisina")
                        .HasColumnType("decimal(7,4)");

                    b.Property<string>("NazivJavnegaObjekta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NickName")
                        .HasColumnType("TEXT");

                    b.Property<int>("ObracunskaMoc")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ogrevanje")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OgrevanjeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OgrevanjeOznaka")
                        .HasColumnType("TEXT");

                    b.Property<string>("SifraJavnegaObjekta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StMerilnegaMesta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("ZemljepisnaDolzina")
                        .HasColumnType("decimal(7,4)");

                    b.Property<decimal?>("ZemljepisnaSirina")
                        .HasColumnType("decimal(7,4)");

                    b.HasKey("Id");

                    b.HasIndex("EnergentTip");

                    b.HasIndex("IdStavbe");

                    b.HasIndex("SifraJavnegaObjekta");

                    b.HasIndex("StMerilnegaMesta");

                    b.ToTable("MerilnaMesta");
                });

            modelBuilder.Entity("API.Entities.Odcitek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("DOEnergijaEuro")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("DOObracunskaMocEuro")
                        .HasColumnType("decimal(9,2)");

                    b.Property<DateTime>("DatumOdcitka")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("ELEEnergijaEUR")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("ELEOmreznina")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("ELEPrispevki")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("EleJalovaEnergija")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("EleenergijaET")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("EleenergijaMt")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("EleenergijaVt")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("EleobracunskaMoc")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("ElkoLbUnpEnergijskiEkvivalent")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("ElkoLbUnpEnotaMere")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("ElkoLbUnpKolicina")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("EnergentTip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Energija")
                        .HasColumnType("decimal(9,2)");

                    b.Property<int>("IdJavnegaObjekta")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdMerilnegaMesta")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("KANALCCNOmrezninaEur")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("KANALCiscenjeVodeEur")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("KANALKanalscinaEur")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("KANALOmrezninaEur")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("KANALZnesek")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("LetoMesec")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NazivMerilnegaMesta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ObdobjeStoritveDo")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ObdobjeStoritveOd")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("PLINDistribucija")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("PLINOdjemnaMoc")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("PLINPorabaKWh")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("PLINPrispevki")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("PLINSkupajBruto")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("PLINZemeljskiPlin")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("SMETIEmbalazaEur")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("SMETIObdelavaBioEur")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("SMETIObdelavaMKOEur")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("SMETIOdlaganjeMKOEur")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("SMETIOpomba")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("SMETIPapirKartonEur")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("SMETIZbiranjeBioEur")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("SMETIZbiranjeMKOEur")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("SMETIZnesek")
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("StMerilnegaMesta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StevilkaRacuna")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipOgrevanja")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipOgrevanjaOznaka")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("VODAOmrezninaEur")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("VODAPorabaM3")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("VODAPrispevekEur")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("VODAVodarinaEur")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal?>("VODAZnesek")
                        .HasColumnType("decimal(9,2)");

                    b.Property<decimal>("Znesek")
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("Id");

                    b.HasIndex("EnergentTip");

                    b.HasIndex("IdJavnegaObjekta");

                    b.HasIndex("IdMerilnegaMesta");

                    b.HasIndex("LetoMesec");

                    b.HasIndex("StMerilnegaMesta");

                    b.ToTable("Odcitki");
                });

            modelBuilder.Entity("API.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AppUserId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMain")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PublicId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("API.Entities.Stavba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("KatastrskaObcinaIme")
                        .HasColumnType("TEXT");

                    b.Property<string>("KatastrskaObcinaSifra")
                        .HasColumnType("TEXT");

                    b.Property<string>("KlasifikacijaCcSi")
                        .HasColumnType("TEXT");

                    b.Property<string>("KlasifikacijaNaziv")
                        .HasColumnType("TEXT");

                    b.Property<string>("KlimatskiKraj")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("KondicioniranaPovrsina")
                        .HasColumnType("decimal(7,2)");

                    b.Property<string>("LetoIzgradnje")
                        .HasColumnType("TEXT");

                    b.Property<string>("LetoObnove")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("NTP_NetoTloris")
                        .HasColumnType("decimal(7,2)");

                    b.Property<decimal?>("NadmorskaVisina")
                        .HasColumnType("decimal(7,4)");

                    b.Property<string>("Naslov")
                        .HasColumnType("TEXT");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NazivEnote")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ogrevanje")
                        .HasColumnType("TEXT");

                    b.Property<string>("OgrevanjeDrugi")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OgrevanjeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OgrevanjeOznaka")
                        .HasColumnType("TEXT");

                    b.Property<string>("Opomba")
                        .HasColumnType("TEXT");

                    b.Property<string>("Parcele")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("ParcelePovrsina")
                        .HasColumnType("decimal(7,2)");

                    b.Property<decimal?>("PovrsinaAplikacija")
                        .HasColumnType("decimal(7,2)");

                    b.Property<decimal?>("ProjekcijaTloris")
                        .HasColumnType("decimal(7,2)");

                    b.Property<string>("ST_OBJ_Gurs")
                        .HasColumnType("TEXT");

                    b.Property<string>("SifraJavnegaObjekta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("StavbaDaNe")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StavbaDel")
                        .HasColumnType("TEXT");

                    b.Property<string>("StavbaStevilka")
                        .HasColumnType("TEXT");

                    b.Property<string>("UlicaHs")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("UporabnaPovrsina")
                        .HasColumnType("decimal(7,2)");

                    b.Property<string>("VrstaObjekta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VrstaObjektaId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("ZemljepisnaDolzina")
                        .HasColumnType("decimal(7,4)");

                    b.Property<decimal?>("ZemljepisnaSirina")
                        .HasColumnType("decimal(7,4)");

                    b.HasKey("Id");

                    b.HasIndex("Naziv");

                    b.HasIndex("SifraJavnegaObjekta");

                    b.HasIndex("VrstaObjekta");

                    b.ToTable("Stavbe");
                });

            modelBuilder.Entity("API.Entities.MerilnoMesto", b =>
                {
                    b.HasOne("API.Entities.Stavba", "Stavba")
                        .WithMany("MerilnaMesta")
                        .HasForeignKey("IdStavbe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stavba");
                });

            modelBuilder.Entity("API.Entities.Odcitek", b =>
                {
                    b.HasOne("API.Entities.MerilnoMesto", "MerilnoMesto")
                        .WithMany("Odcitki")
                        .HasForeignKey("IdMerilnegaMesta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MerilnoMesto");
                });

            modelBuilder.Entity("API.Entities.Photo", b =>
                {
                    b.HasOne("API.Entities.AppUser", "AppUser")
                        .WithMany("Photos")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("API.Entities.MerilnoMesto", b =>
                {
                    b.Navigation("Odcitki");
                });

            modelBuilder.Entity("API.Entities.Stavba", b =>
                {
                    b.Navigation("MerilnaMesta");
                });
#pragma warning restore 612, 618
        }
    }
}
