using System;

namespace API.Helpers;

public class StavbaParams : PaginationParams
{
    public string? Naziv { get; set; }
    public string?  VrstaObjekta { get; set; }

}
