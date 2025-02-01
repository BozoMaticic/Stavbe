using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Stavba> Stavbe { get; set; }
        public DbSet<MerilnoMesto> MerilnaMesta { get; set; }
        public DbSet<Odcitek> Odcitki { get; set; }
    }
