using Microsoft.EntityFrameworkCore;
using RaceDay.API.Models;
using System.Collections.Generic;

namespace RaceDay.API.Data
{
    public class RaceDayDbContext : DbContext
    {
        public RaceDayDbContext(DbContextOptions<RaceDayDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
    }
}
