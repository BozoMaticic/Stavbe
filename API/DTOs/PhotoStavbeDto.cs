using System;

namespace API.DTOs;

public class PhotoStavbeDto
{
    public int Id { get; set; }
    public string? Url { get; set; }
    public bool IsMain { get; set; }
   // public DateTime DateAdded { get; set; } = DateTime.Now;

}
