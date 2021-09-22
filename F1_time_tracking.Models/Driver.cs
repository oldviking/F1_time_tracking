using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_time_tracking.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
