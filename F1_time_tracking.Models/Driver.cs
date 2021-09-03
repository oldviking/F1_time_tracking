using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_time_tracking.Models
{
    public class Driver
    {
        public int DriverID { get; set; }
        public string Name { get; set; }

        public int TeamID { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}
