using System;
using API.Entities.MojElektro;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class MojElektroController(IMojElektroRepository mojElektroRepository) : BaseApiController
{
    [HttpGet("moj-elektro-merilna-mesta/{nazivStavbe}")]
    public async Task<ActionResult<MojElektroMerilnoMesto[]>> GetMojElektroMerilnaMesta(string nazivStavbe)
    {
        var mojEleMerMesta = await mojElektroRepository.GetMojElektroMerilnaMesta(nazivStavbe);
        if (mojEleMerMesta == null) return NotFound();
        return Ok(mojEleMerMesta);
    }



}
