﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Models
{
    public class OrdersDetailsViewModel
    {
        [Key]
        public int OrderDetailsId { get; set; }

        public OrderViewModels Order { get; set; }
        public IEnumerable<SelectListItem> Orders { get; set; }
        public int OrderId { get; set; }


        public ProductViewModel Product { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }
        public int ProductId { get; set; }
    }
}
