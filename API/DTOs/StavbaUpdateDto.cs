using System;

namespace API.DTOs;

public class StavbaUpdateDto
{
        public int Id { get; set; }
        public string? Naziv { get; set; }
        public string? Naslov { get; set; }
        public string? Opomba { get; set; }
        public string? UlicaHs { get; set; }

}
