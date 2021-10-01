using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_time_tracking.Models
{
    public class Team
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; } = new ObservableCollection<Driver>();
    }
}
