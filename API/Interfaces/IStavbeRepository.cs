using System;
using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IStavbeRepository
{
    // void Update(Stavba stavba);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<StavbaDto>> GetStavbeAsync();
    Task<StavbaDto?> GetStavbaByIdAsync(int id);
    Task<StavbaDto?> GetStavbaByNazivAsync(string nazivStavbe);
}
