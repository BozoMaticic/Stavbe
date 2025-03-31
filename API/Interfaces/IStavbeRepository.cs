using System;
using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IStavbeRepository
{
    Task<bool> SaveAllAsync();
    Task<IEnumerable<StavbaDto>> GetStavbeAsync();
    Task<Stavba?> GetStavbaByIdAsync(int id);
    Task<StavbaDto?> GetStavbaDtoByIdAsync(int id);
    Task<Stavba?> GetStavbaByNazivAsync(string nazivStavbe);
    Task<StavbaDto?> GetStavbaDtoByNazivAsync(string nazivStavbe);
  //  Task<Stavba> UpdateAsync(Stavba stavba);
}
