using System;
using API.Entities;
using API.Entities.MojElektro;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Stavba> Stavbe { get; set; }
    public DbSet<MerilnoMesto> MerilnaMesta { get; set; }
    public DbSet<Odcitek> Odcitki { get; set; }
    public DbSet<GeoTocka> GeoTocke { get; set; } = null!;
    public DbSet<MojElektroMerilnoMesto> MojElektroMerilnaMesta { get; set; }
    public DbSet<MojElektro15MinMeritev> MojElektro15MinMeritve { get; set; }

}
