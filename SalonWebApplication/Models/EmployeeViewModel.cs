using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeImg { get; set; }

        [Required(ErrorMessage = "Please upload an image")]
        [Display(Name = "Image")]
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public Microsoft.AspNetCore.Http.IFormFile Image { get; set; }

        public string EmployeeDOb { get; set; }
        public string EmployeeGender { get; set; }
        public string EmployeeContact { get; set; }
    }
}
