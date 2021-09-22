using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace F1_time_tracking.Models
{
    public class Season
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Race> Races { get; set; } = new ObservableCollection<Race>();
    }
}
