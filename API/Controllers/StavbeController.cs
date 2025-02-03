using System;
using API.Data;
using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class StavbeController(IStavbeRepository stavbeRepository) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StavbaDto>>> GetStavbe()
    {
        var stavbe = await stavbeRepository.GetStavbeAsync();
        return Ok(stavbe);
    }

    
    [HttpGet("{nazivStavbe}")]
    public async Task<ActionResult<StavbaDto>> GetStavbaPoNazivu(string nazivStavbe)
    {
        var stavba = await stavbeRepository.GetStavbaByNazivAsync(nazivStavbe);
        if (stavba == null) return NotFound();
        return stavba;
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<StavbaDto>> GetStavba(int id)
    {
        var stavba = await stavbeRepository.GetStavbaByIdAsync(id);
        if (stavba == null) return NotFound();
        return stavba;
    }



    // [HttpPut("{id}")]
    // public async Task<ActionResult> UpdateStavba(int id, StavbaDto stavbaDto)
    // {
    //     var stavba = await stavbeRepository.GetStavbaByIdAsync(id);
    //     if (stavba == null) return NotFound();
    //     stavbeRepository.Update(stavbaDto);
    //     if (await stavbeRepository.SaveAllAsync()) return NoContent();
    //     return BadRequest("Failed to update stavba");
    // }

}
