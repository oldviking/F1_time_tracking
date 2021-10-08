using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace F1_time_tracking.Models
{
    public class Team
    {
        public int Id { get; set; }

        [MaxLength(80)]
        public string Name { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; } = new ObservableCollection<Driver>();
    }
}