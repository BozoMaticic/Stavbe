using System;
using API.Entities;

namespace API.DTOs;

public class StavbaDto
{
    public int Id { get; set; }
    public string SifraJavnegaObjekta { get; set; } = null!;
    public string Naziv { get; set; } = null!;
    public string? PhotoUrl { get; set; }     // slika stavbe

    public string? NazivEnote { get; set; } = null!;
    public string? Naslov { get; set; } = null!;
    public string? UlicaHs { get; set; } = null!;
    public string? KatastrskaObcinaSifra { get; set; } = null!;
    public string? KatastrskaObcinaIme { get; set; } = null!;
    public string? ST_OBJ_Gurs { get; set; } = null!;
    public decimal? NTP_NetoTloris { get; set; }
    public decimal? UporabnaPovrsina { get; set; }
    public string VrstaObjekta { get; set; } = null!;
    public int VrstaObjektaId { get; set; }
    public string? Ogrevanje { get; set; } = null!;
    public int? OgrevanjeId { get; set; }
    public string? OgrevanjeOznaka { get; set; } = null!;
    public decimal? ParcelePovrsina { get; set; }
    public bool? StavbaDaNe { get; set; }
    public string? StavbaStevilka { get; set; } = null!;
    public string? StavbaDel { get; set; } = null!;
    public string? KlasifikacijaCcSi { get; set; } = null!;
    public string? KlasifikacijaNaziv { get; set; } = null!;
    public decimal? PovrsinaAplikacija { get; set; }

    #region Navigation Properties
    public List<PhotoStavbe>? PhotoStavbe { get; set; } = null!;

    public ICollection<MerilnoMestoDto>? MerilnaMesta { get; set; } = null!;

    #endregion
}
