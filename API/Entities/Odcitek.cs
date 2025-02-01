using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Entities;

[Table("Odcitki")]
[Index(nameof(IdJavnegaObjekta))]
[Index(nameof(StMerilnegaMesta))]
[Index(nameof(EnergentTip))]
[Index(nameof(LetoMesec))]

public class Odcitek
{
    public int Id { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int IdJavnegaObjekta { get; set; }
    public string StMerilnegaMesta { get; set; } = null!;
    public string NazivMerilnegaMesta { get; set; } = null!;
    public string EnergentTip { get; set; } = null!;
    public int? Type { get; set; }

    public string? TipOgrevanja { get; set; } = null!;
    public string? TipOgrevanjaOznaka { get; set; } = null!;

    public string? StevilkaRacuna { get; set; } = null!;
    public DateTime DatumOdcitka { get; set; }
    public DateTime? ObdobjeStoritveOd { get; set; }
    public DateTime? ObdobjeStoritveDo { get; set; }
    public string LetoMesec { get; set; } = null!;

    [Column(TypeName = "decimal(9,2)")]
    public decimal? Energija { get; set; }  // kWH

    [Column(TypeName = "decimal(9,2)")]
    public decimal Znesek { get; set; }     // EUR

    // Elektrika
    #region Elektrika

    [Column(TypeName = "decimal(9,2)")]
    public decimal? EleenergijaVt { get; set; }     // kWh

    [Column(TypeName = "decimal(9,2)")]
    public decimal? EleenergijaMt { get; set; }     // kWh

    [Column(TypeName = "decimal(9,2)")]
    public decimal? EleenergijaET { get; set; }     // kWh

    [Column(TypeName = "decimal(9,2)")]
    public decimal? EleobracunskaMoc { get; set; }  // kW

    [Column(TypeName = "decimal(9,2)")]
    public decimal? EleJalovaEnergija { get; set; }  //  (kVArh)


    [Column(TypeName = "decimal(9,2)")]
    public decimal? ELEEnergijaEUR { get; set; }     // EUR

    [Column(TypeName = "decimal(9,2)")]
    public decimal? ELEOmreznina { get; set; }     // EUR

    [Column(TypeName = "decimal(9,2)")]
    public decimal? ELEPrispevki { get; set; }     // EUR
    #endregion

    // PLIN 
    #region Plin
    [Column(TypeName = "decimal(9,2)")]
    public decimal? PLINPorabaKWh { get; set; }     // kWh

    [Column(TypeName = "decimal(9,2)")]
    public decimal? PLINOdjemnaMoc { get; set; }            // kW

    [Column(TypeName = "decimal(9,2)")]
    public decimal? PLINSkupajBruto { get; set; }               //EUR

    [Column(TypeName = "decimal(9,2)")]
    public decimal? PLINZemeljskiPlin { get; set; }         //EUR

    [Column(TypeName = "decimal(9,2)")]
    public decimal? PLINDistribucija { get; set; }            //EUR

    [Column(TypeName = "decimal(9,2)")]
    public decimal? PLINPrispevki { get; set; }            //EUR
    #endregion


    // DO daljinsko ogrevanje

    [Column(TypeName = "decimal(9,2)")]
    public decimal? DOObracunskaMocEuro { get; set; }            //EUR

    [Column(TypeName = "decimal(9,2)")]
    public decimal? DOEnergijaEuro { get; set; }            //EUR



    // ELKO kurilno olje  +  LB lesna biomasa  +  UNP utekočinjen naftni plin
    #region ELKO + LB + UNP
    public string? ElkoLbUnpEnotaMere { get; set; } = null!;

    [Column(TypeName = "decimal(9,2)")]
    public decimal? ElkoLbUnpKolicina { get; set; }

    [Column(TypeName = "decimal(9,2)")]
    public decimal? ElkoLbUnpEnergijskiEkvivalent { get; set; }
    #endregion

    // Voda + Kanal
    #region VODA + Kanal
    [Column(TypeName = "decimal(9,2)")]
    public decimal? VODAPorabaM3 { get; set; }    // m3

    [Column(TypeName = "decimal(9,2)")]
    public decimal? VODAVodarinaEur { get; set; }    // EUR

    [Column(TypeName = "decimal(9,2)")]
    public decimal? VODAPrispevekEur { get; set; }    //

    [Column(TypeName = "decimal(9,2)")]
    public decimal? VODAOmrezninaEur { get; set; }    //

    [Column(TypeName = "decimal(9,2)")]
    public decimal? VODAZnesek { get; set; }

    [Column(TypeName = "decimal(9,2)")]
    public decimal? KANALKanalscinaEur { get; set; }

    [Column(TypeName = "decimal(9,2)")]
    public decimal? KANALOmrezninaEur { get; set; }

    [Column(TypeName = "decimal(9,2)")]
    public decimal? KANALCiscenjeVodeEur { get; set; }

    [Column(TypeName = "decimal(9,2)")]
    public decimal? KANALCCNOmrezninaEur { get; set; }  // centralna čistilna naprava CČN

    [Column(TypeName = "decimal(9,2)")]
    public decimal? KANALZnesek { get; set; }
    #endregion

    //Smeti
    #region ODPADKI
    [Column(TypeName = "decimal(9,2)")]
    public decimal? SMETIPapirKartonEur { get; set; }

    [Column(TypeName = "decimal(9,2)")]
    public decimal? SMETIEmbalazaEur { get; set; }

    [Column(TypeName = "decimal(9,2)")]
    public decimal? SMETIZbiranjeBioEur { get; set; }

    [Column(TypeName = "decimal(9,2)")]
    public decimal? SMETIObdelavaBioEur { get; set; }

    [Column(TypeName = "decimal(9,2)")]
    public decimal? SMETIZbiranjeMKOEur { get; set; }

    [Column(TypeName = "decimal(9,2)")]
    public decimal? SMETIObdelavaMKOEur { get; set; }

    [Column(TypeName = "decimal(9,2)")]
    public decimal? SMETIOdlaganjeMKOEur { get; set; }

    [Column(TypeName = "decimal(9,2)")]
    public decimal? SMETIZnesek { get; set; }

    public string? SMETIOpomba { get; set; } = null!;
    #endregion


    #region Navigation Properties
    /// Id merilnega mesta na katerega je povezan ta odčitek
    [ForeignKey(nameof(MerilnoMesto))]
    public int IdMerilnegaMesta { get; set; }

    public MerilnoMesto? MerilnoMesto { get; set; } = null!;
    #endregion


    // TC toplotna črpalka
    //


}
