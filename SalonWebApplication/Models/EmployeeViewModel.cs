using System.ComponentModel;
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
           [DisplayName("Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string EmployeeDOb { get; set; }
        [Required]
        public string EmployeeGender { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
          ErrorMessage = "Entered phone format is not valid.")]

        public string EmployeeContact { get; set; }
    }
}
