using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project3data.Models;

namespace project3data.Data
{
    public class DatabaseContext : DbContext
    {

        public DbSet<District> Districts { get; set; }
        public DbSet<BicycleCrime> BicycleCrimes { get; set; }
        public DbSet<StreetCrime> StreetCrimes { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext>options):base(options)
        {

        }
    }
}