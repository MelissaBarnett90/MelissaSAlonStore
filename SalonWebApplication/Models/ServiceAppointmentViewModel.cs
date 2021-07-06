using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Models
{
    public class ServiceAppointmentViewModel
    {
        public int ServiceAppointmentId { get; set; }

        public ServiceViewModel Service { get; set; }
        public IEnumerable<SelectListItem> Services { get; set; }
        public int ServiceId { get; set; }


        public AppointmentViewModel Appointment { get; set; }
        public IEnumerable<SelectListItem> Appointments { get; set; }
        public int AppointmentId { get; set; }
    }
}
