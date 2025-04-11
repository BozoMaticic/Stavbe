namespace API.Helpers;

public class StavbaParams : PaginationParams
{
    public string? Naziv { get; set; }
    public string? CurrentStavbaNaziv { get; set; }
    public string?  VrstaObjekta { get; set; } = "vsi";
    public string? TipOgrevanja { get; set; } = "vsi";

}
