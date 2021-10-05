using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using F1_time_tracking.Models;

namespace F1_time_tracking.Data
{
    public class F1Context : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Models.Results> Result { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        public DbSet<DriverTeam> driverTeams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=Formel1;Trusted_Connection=True;MultipleActiveResultSets=true");
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Driver>().HasMany(x => x.Team)
                    .WithMany(x => x.Drivers)
                    .UsingEntity<DriverTeam>(
                        x => x.HasOne(x => x.Team)
                        .WithMany().HasForeignKey(x => x.TeamID),
                        x => x.HasOne(x => x.Driver)
                       .WithMany().HasForeignKey(x => x.DriverID),
                        x => x.HasOne(x => x.Season)
                        .WithMany().HasForeignKey(x => x.SeasonID));

        }



    }
}
