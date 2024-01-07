using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer
{
    public class DatabaseContext : DbContext
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["ParkbeheerOpgave"].ConnectionString;
        public DbSet<HuurderEF> Huurders { get; set; }
        public DbSet<ParkEF> Parken { get; set; }
        public DbSet<HuurContractEF> HuurContracten { get; set; }
        public DbSet<HuisEF> Huizen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            //.LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
