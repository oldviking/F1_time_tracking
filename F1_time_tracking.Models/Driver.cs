using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace F1_time_tracking.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public int TeamId { get; set; }

        [MaxLength(80)]
        public string FirstName { get; set; }

        [MaxLength(80)]
        public string LastName { get; set; }

        public ICollection<Team> Team { get; set; }

        /// <summary>
        /// A Prop for displaying the name on an easy way, it's not writen to the database
        /// </summary>
        public string Name { get { return FirstName + " " + LastName; } }
    }
}
}