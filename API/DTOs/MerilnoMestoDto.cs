using System;
using System.ComponentModel.DataAnnotations.Schema;
using API.Entities;

namespace API.DTOs;

public class MerilnoMestoDto
{
    public int Id { get; set; }
    public string StMerilnegaMesta { get; set; } = null!;
    public int Energent { get; set; }
    public string EnergentTip { get; set; } = null!;
    public int? Type { get; set; }
    public string? Ogrevanje { get; set; } = null!;
    public int? OgrevanjeId { get; set; }
    public string? OgrevanjeOznaka { get; set; } = null!;

    public int IdJavnegaZavoda { get; set; }
    public string SifraJavnegaObjekta { get; set; } = null!;
    public string NazivJavnegaObjekta { get; set; } = null!;
    public string? NickName { get; set; } = null!;
    public string Dobavitelj { get; set; } = null!;
    public string? DobaviteljNaziv { get; set; } = null!;
    public int ObracunskaMoc { get; set; }

    #region Navigation Properties
    public Stavba? Stavba { get; set; } = null!;
    [ForeignKey(nameof(Stavba))]
    public int IdStavbe { get; set; }
    public ICollection<Odcitek>? Odcitki { get; set; } = null!;
    #endregion



}
