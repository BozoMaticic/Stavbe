using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;
[Table("PhotoStavbe")]
public class PhotoStavbe
{
    public int Id { get; set; }
    public required string Url { get; set; }
    public bool IsMain { get; set; }
    public string? PublicId { get; set; }

    // navigation properties
    public int StavbaId { get; set; }
    public Stavba Stavba { get; set; } = null!;   // null forgiving operator


}
