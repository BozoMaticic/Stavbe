using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities.MojElektro;

[Table("MojElektroMerilnaMesta")]
public class MojElektroMerilnoMesto
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string? EnotniIdentifikator { get; set; }
    public string SifraJavnegaObjekta { get; set; } = null!;
    public string NazivJavnegaObjekta { get; set; } = null!;

    public string? GsrnMM { get; set; }
    public string? Naziv { get; set; }
    public string? Naslov { get; set; }
    public string? RTP { get; set; }
    public string? SNizvod { get; set; }
    public string? TP { get; set; }
    public string? NNizvod { get; set; }
    public string? Dobavitelj { get; set; }

    #region
    /// <summary>
    /// Id Javnega objekta na katerega je povezano to merilno mesto
    /// </summary>
    [ForeignKey(nameof(Stavba))]
    public int IdJavnegaObjekta { get; set; }
    #endregion

    #region Navigation Properties
    /// <summary>
    /// 
    /// </summary>
    public Stavba? Stavba { get; set; } = null!;
    public ICollection<MojElektro15MinMeritev>? Meritve15min { get; set; } = null!;

    #endregion



}
