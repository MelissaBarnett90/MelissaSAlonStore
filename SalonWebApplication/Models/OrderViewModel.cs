using Microsoft.AspNetCore.Mvc.Rendering;
using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Models
{
    public class OrderViewModel
    {
        [Key]
        public int OrderId { get; set; }    

         
        public CustomerViewModel Customer { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
        [Display(Name ="Customer Name")]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }

        public DateTime OrderDate { get; set; }

        public double Total { get; set; }

        public PaymentTypeViewModel PaymentType { get; set; }
        public IEnumerable<SelectListItem> PaymentTypes { get; set; }
        public int PaymentTypeId { get; set; }
        public string Paymentname { get; set; }


     

        public ProductViewModel Product { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public double Productprice { get; set; }
    }
}
