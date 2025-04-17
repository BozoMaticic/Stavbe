using System;

namespace API.DTOs;

public class GeoTockaDto
{
            public int Id { get; set; }

        public string SifraObjekta { get; set; } = null!;
      //  public string? SifraMerilnegaMesta { get; set; } = null!;
        public int? Zaporedje { get; set; }

        public decimal? Lat { get; set; }

        public decimal? Lng { get; set; }
      //  public string? JavniObjektSifraJavnegaObjekta { get; set; } = null!;


        //  Kamnik
        public int? FID { get; set; }
        public string? OZN_obj { get; set; } = null!;
        public string? Naziv { get; set; } = null!;
        public string? SID { get; set; } = null!;
        public string? SIFKO { get; set; } = null!;
        public string? ST_stevilka { get; set; } = null!;
        public string? Ozn_tock { get; set; } = null!;

        public decimal? DDLat { get; set; }
        public decimal? DDLon { get; set; }
        // -- Kamnik

        public int IdJavnegaObjekta { get; set; }

}
