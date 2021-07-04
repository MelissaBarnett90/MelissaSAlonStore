using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public float ProductCost { get; set; }
        public int ProductQty { get; set; }
        public byte[] ProductImg { get; set; }


    }
}
