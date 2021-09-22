using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_time_tracking.Models
{
    public class Results
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public int RaceId { get; set; }
        public virtual Race Race { get; set; }
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
