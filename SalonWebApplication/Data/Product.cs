using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Data
{
    public class Product
    {   [Key]
        public int Id { get; set; }
        [Required]

        public string ProductName { get; set; }
        [Required]

        public float ProductCost { get; set; }
        [Required]

        public int ProductQty { get; set; }
        [Required]

        public byte[] ProductImg { get; set; }
        [Required]


    }
}
