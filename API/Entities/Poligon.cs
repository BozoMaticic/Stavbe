using System;

namespace API.Entities;

public class Tocka
{
    public decimal? Lat { get; set; }
    public decimal? Lng { get; set; }
}

public class TockaOboda
{
    public int? Zaporedje { get; set; }
    public Tocka? Tocka { get; set; }

}

public class Poligon 
{
    public int IdJavnegaObjekta { get; set; }
    public string? SifraJavnegaObjekta { get; set; }
    public string? Naziv { get; set; }


    public List<TockaOboda>? TockeOboda { get; set; }
    public List<List<Tocka>>? NoviObodiObjekta { get; set; }

}



