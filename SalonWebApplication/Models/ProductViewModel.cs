using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Models
{
    public class ProductViewModel
    {
        [Key]
        public int ProductId { get; set; }
        [Required]

        public string ProductName { get; set; }
        [Required]

        public float ProductCost { get; set; }
        [Required]

        public int ProductQty { get; set; }

        public string ProductImg { get; set; }


        [Required(ErrorMessage = "Please upload an image")]
        [Display(Name = "Picture")]
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public Microsoft.AspNetCore.Http.IFormFile Picture { get; set;}


    }
}
