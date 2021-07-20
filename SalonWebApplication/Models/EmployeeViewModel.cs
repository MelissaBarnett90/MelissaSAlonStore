using System.ComponentModel.DataAnnotations;

namespace SalonWebApplication.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string EmployeeImg { get; set; }

        [Required(ErrorMessage = "Please upload an image")]
        [Display(Name = "Image")]
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public Microsoft.AspNetCore.Http.IFormFile Image { get; set; }
        [Required]
        public string EmployeeDOb { get; set; }
        [Required]
        public string EmployeeGender { get; set; }
        [Required]
        public string EmployeeContact { get; set; }
    }
}
