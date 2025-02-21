using System;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Repos;

public class StavbeRepository(DataContext context, IMapper mapper) : IStavbeRepository
{
    public async Task<IEnumerable<StavbaDto>> GetStavbeAsync()
    {
        return await context.Stavbe
        .Include(x => x.MerilnaMesta)
        .ProjectTo<StavbaDto>(mapper.ConfigurationProvider)
        .ToListAsync();
    }

    public async Task<StavbaDto?> GetStavbaByNazivAsync(string nazivStavbe)
    {
        return await context.Stavbe
        .Where(x => x.Naziv == nazivStavbe)
        .Include(x => x.PhotoStavbe)
        .ProjectTo<StavbaDto>(mapper.ConfigurationProvider)
        .SingleOrDefaultAsync();
    }

    public async Task<StavbaDto?> GetStavbaByIdAsync(int id)
    {
        return await context.Stavbe
        .Include(x => x.PhotoStavbe)
        .Where(x => x.Id == id)
        .ProjectTo<StavbaDto>(mapper.ConfigurationProvider)
        .SingleOrDefaultAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    // public void Update(StavbaDto stavba)
    // {
    //     context.Entry(stavba).State = EntityState.Modified;
    // }
}
