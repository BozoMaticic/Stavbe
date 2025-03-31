using System;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class StavbeController(IStavbeRepository stavbeRepository, IMapper mapper, 
    IPhotoService photoService) : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StavbaDto>>> GetStavbe()
    {
        var stavbe = await stavbeRepository.GetStavbeAsync();
        return Ok(stavbe);
    }

    [HttpGet("{nazivStavbe}")]
    public async Task<ActionResult<StavbaDto>> GetStavbaPoNazivu(string nazivStavbe)
    {
        var stavba = await stavbeRepository.GetStavbaDtoByNazivAsync(nazivStavbe);
        if (stavba == null) return NotFound();
        return stavba;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Stavba>> GetStavba(int id)
    {
        var stavba = await stavbeRepository.GetStavbaByIdAsync(id);
        if (stavba == null) return NotFound();
        return stavba;
    }

    [HttpPut]
    public async Task<ActionResult> Update(StavbaUpdateDto stavbaUpdateDto)
    {
        var stavba = await stavbeRepository.GetStavbaByIdAsync(stavbaUpdateDto.Id);
        if (stavba == null) return NotFound();
        mapper.Map(stavbaUpdateDto, stavba);

        if (await stavbeRepository.SaveAllAsync()) return NoContent();
        return BadRequest("Failed to update stavba");
    }

    [HttpPost("add-photo/{naziv}")]
    public async Task<ActionResult<PhotoDto>> AddPhoto([FromQuery]IFormFile file, string naziv)
    {
       // var id = 3; // vzamemo prvo stavbo za testiranje

        var stavba = await stavbeRepository.GetStavbaByNazivAsync(naziv);
        if (stavba == null) return BadRequest("Cannot update stavba");

        var result = await photoService.AddPhotoAsync(file);
        if (result.Error != null) return BadRequest(result.Error.Message);

        var photoStavbe = new PhotoStavbe
        {
            Url = result.SecureUrl.AbsoluteUri,
            PublicId = result.PublicId
        };

        stavba.PhotosStavbe?.Add(photoStavbe);

        if (await stavbeRepository.SaveAllAsync())
        {
            return CreatedAtAction(nameof(GetStavba), 
                new { id = stavba.Id }, mapper.Map<PhotoDto>(photoStavbe));
        }
        return BadRequest("Problem adding photo");
    }

    [HttpPut("set-main-photo/{idStavbeIdFoto}")]
    public async Task<ActionResult> SetMainPhoto(string idStavbeIdFoto)
    {
        var stavbaId = int.Parse(idStavbeIdFoto.Split(' ')[0]) ;
        var photoId = int.Parse(idStavbeIdFoto.Split(' ')[1]);
        //var stavbaNaziv = "Občina Kamnik"; // testiranje

        if (stavbaId == 0) return BadRequest("Stavba ne obstaja");
        if (photoId == 0) return BadRequest("PhotoId ne obstaja");
        
        var stavba = await stavbeRepository.GetStavbaByIdAsync(stavbaId);
        if (stavba == null) return BadRequest("Stavba ne obstaja");
        var photo = stavba.PhotosStavbe.FirstOrDefault(x => x.Id == photoId);
        if (photo == null || photo.IsMain) return BadRequest("Cannot use this as main photo");

        var currentMain = stavba.PhotosStavbe.FirstOrDefault(x => x.IsMain);
        if (currentMain != null) currentMain.IsMain = false;
        photo.IsMain = true;

        if (await stavbeRepository.SaveAllAsync()) return NoContent();

        return BadRequest("Problem setting main photo za stavbo");
    }

    //  [HttpDelete("delete-photo/{photoId:int}")]
    //  public async Task<ActionResult> DeletePhoto(int photoId)
    //  {
    //     var user = await userRepository.GetUserByNameAsync(User.GetUserName());
    //     if (user == null) return BadRequest("User not found");
        
    //     var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);
    //     if (photo == null || photo.IsMain) return BadRequest("This photo cannot be deleted");

    //     if (photo.PublicId != null)
    //     {
    //         var result = await photoService.DeletePhotoAsync(photo.PublicId);
    //         if (result.Error != null) return BadRequest(result.Error.Message);
    //     }

    //     user.Photos.Remove(photo);

    //     if (await userRepository.SaveAllAsync()) return Ok();

    //     return BadRequest("Problem deleting photo");
    //  }



}
