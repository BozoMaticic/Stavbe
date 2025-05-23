using System;
using API.Entities.MojElektro;

namespace API.Interfaces;

public interface IMojElektroRepository
{
    Task<MojElektroMerilnoMesto[]> GetMojElektroMerilnaMesta(string nazivStavbe);

}
