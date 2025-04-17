using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Entities;

    // [Table("Stavbe")]
    // [Index(nameof(Naziv))]
public class Stavba
{
    public int Id { get; set; }
    public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; } = DateTime.UtcNow;
    public string SifraJavnegaObjekta { get; set; } = null!;
    public string Naziv { get; set; } = null!;
    public string? NazivEnote { get; set; } = null!;
    public string? Naslov { get; set; } = null!;
    public string? UlicaHs { get; set; } = null!;
    public string? KatastrskaObcinaSifra { get; set; } = null!;
    public string? KatastrskaObcinaIme { get; set; } = null!;
    public string? ST_OBJ_Gurs { get; set; } = null!;

    [Column(TypeName = "decimal(7,2)")]
    public decimal? NTP_NetoTloris { get; set; }

    [Column(TypeName = "decimal(7,2)")]
    public decimal? UporabnaPovrsina { get; set; }

    [Column(TypeName = "decimal(7,2)")]
    public decimal? ProjekcijaTloris { get; set; }

    public string VrstaObjekta { get; set; } = null!;
    public int VrstaObjektaId { get; set; }
    public string? Ogrevanje { get; set; } = null!;
    public int? OgrevanjeId { get; set; }
    public string? OgrevanjeOznaka { get; set; } = null!;
    public string? OgrevanjeDrugi { get; set; } = null!;
    public string? Opomba { get; set; } = null!;
    public string? Parcele { get; set; } = null!;

    [Column(TypeName = "decimal(7,2)")]
    public decimal? ParcelePovrsina { get; set; }
    public bool? StavbaDaNe { get; set; }
    public string? StavbaStevilka { get; set; } = null!;
    public string? StavbaDel { get; set; } = null!;
    public string? KlasifikacijaCcSi { get; set; } = null!;
    public string? KlasifikacijaNaziv { get; set; } = null!;
    [Column(TypeName = "decimal(7,2)")]
    public decimal KondicioniranaPovrsina { get; set; }
    [Column(TypeName = "decimal(7,2)")]
    public decimal? PovrsinaAplikacija { get; set; }
    public string? LetoIzgradnje { get; set; } = null!;
    public string? LetoObnove { get; set; } = null!;
    public string? KlimatskiKraj { get; set; } = null!;
    [Column(TypeName = "decimal(7,4)")]
    public decimal? ZemljepisnaSirina { get; set; }
    [Column(TypeName = "decimal(7,4)")]
    public decimal? ZemljepisnaDolzina { get; set; }
    [Column(TypeName = "decimal(7,4)")]
    public decimal? NadmorskaVisina { get; set; }

    #region Navigation Properties
    public ICollection<MerilnoMesto>? MerilnaMesta { get; set; } = null!;
    // public ICollection<MojElektroMerilnoMesto>? MojElektroMerilnaMesta { get; set; } = null!;
    public ICollection<GeoTocka> GeoTocke { get; set; } = null!;

    public List<PhotoStavbe> PhotosStavbe { get; set; } = [];


    #endregion
}


