using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Services.Models
{
    public class UserModel
    {
        [Display(Name = "Forename")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Forename Required")]
        public string UForename { get; set; }

        [Display(Name = "Surname")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Surname Required")]
        public string USurname { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Index(IsUnique = true)]
        public string UEmail { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of Birth Required")]
        [DataType(DataType.Date)]
        public DateTime UDOB { get; set; }

        [Display(Name = "Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address Required")]
        public string UAddress { get; set; }

        [Display(Name = "Postcode")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Postcode Required")]
        public string UPostcode { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string UPassword { get; set; }
    }
}
