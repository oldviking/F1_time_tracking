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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=Formel1;Trusted_Connection=True;MultipleActiveResultSets=true");
            
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }

    }
}
