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

      
        public Customer Customers { get; set; }
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public double Total { get; set; }

        [ForeignKey ("PaymentTypeId")]
        public PaymentType PaymentTypes { get; set; }

        public int PaymentTypeId { get; set; }
       

    }
}


