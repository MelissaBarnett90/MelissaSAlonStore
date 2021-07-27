using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Data
{
    public class Order
    {
        [Key]
       public int  OrderId { get; set; }

        [ForeignKey("CustomerId")]

        public Customer Customers { get; set; }
       public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }

        public double Total { get; set; }

        [ForeignKey ("PaymentTypeId")]
        public PaymentType PaymentTypes { get; set; }

        public int PaymentTypeId { get; set; }
        public int PaymentName { get; set; }


        [ForeignKey("ProductId")]

        public Product Products { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }

        public int Quantity { get; set; }
    }
}


