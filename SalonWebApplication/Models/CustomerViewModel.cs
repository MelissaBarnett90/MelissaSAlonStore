using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalonWebApplication.Models
{
    public class CustomerViewModel
    {
        [Key]
        public int CustomerId { get; set; }
      [Required]
        public string CustomerFirstName { get; set; }
        [Required]
        public string CustomerLastName { get; set; }
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public String CustomerDOB { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
          ErrorMessage = "Entered phone format is not valid.")]
        public string CustomerContact { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        public string CustomerOccupation { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "TRN")]
        [Required(ErrorMessage = "TAX REGISTRATION NUMBER REQUIRED!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$",
          ErrorMessage = "TRN format is not valid.")]
        public string CustomerTRN { get; set; }
    }
}
