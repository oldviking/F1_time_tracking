using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_time_tracking.Models
{
    public class Results
    {
        public int ID { get; set; }
        public int RaceID { get; set; }
        public int Position { get; set; }
        public Race Race { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
