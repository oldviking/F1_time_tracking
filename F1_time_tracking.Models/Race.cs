﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_time_tracking.Models
{
    public class Race
    {
        public int Id { get; set; }
        public Season Season { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public virtual List<Results> Results { get; set; }
    }
}
