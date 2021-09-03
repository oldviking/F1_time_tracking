using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_time_tracking.Models
{
    public class User
    {
        [Key]
        public string username { get; set; }

        public string password { get; set; }
        public string salt { get; set; }
    }
}

