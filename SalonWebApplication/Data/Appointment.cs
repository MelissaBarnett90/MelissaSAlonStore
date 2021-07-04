using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Data
{
    public class Appointment
    {   [Key]
        public int AppointmentId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public DateTime AppointmentTime { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employees { get; set; }
        public int EmployeeId { get; set; }


        [ForeignKey("CustomerId")]
        public Customer Customers { get; set; }
        public int CustomerId { get; set; }

      
    }
}
