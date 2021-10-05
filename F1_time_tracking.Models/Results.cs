﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_time_tracking.Models
{
    public class Results
    {
        [Key]
        public int Id { get; set; }
        public int Position { get; set; }
        public int Points { get; set; }
        public int RaceId { get; set; }
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Race Race { get; set; }
    }
}
