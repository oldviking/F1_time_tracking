using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_time_tracking.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; } = new ObservableCollection<Driver>();
    }
}
