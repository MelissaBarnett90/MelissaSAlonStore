using Microsoft.AspNetCore.Mvc.Rendering;
using SalonWebApplication.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Models
{
    public class AppointmentViewModel
    {
        [Key]
        public int AppointmentId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public DateTime AppointmentTime { get; set; }

        public EmployeeViewModel Employee { get; set; }
        public IEnumerable<SelectListItem> Employees { get; set; }
              
        public int EmployeeId { get; set; }

        public CustomerViewModel Customer { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }      
        public int CustomerId { get; set; }
    }
}
