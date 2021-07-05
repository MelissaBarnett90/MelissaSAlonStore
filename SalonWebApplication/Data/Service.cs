using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Data
{
    public class Service
    {   [Key]
        public int Id { get; set; }

        public string ServiceName { get; set; }
        [Required]

        public int ServiceCost { get; set; }
        [Required]

        public TimeSpan Duration { get; set; }
     





    }
}
