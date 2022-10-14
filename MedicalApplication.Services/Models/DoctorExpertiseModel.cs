using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Services.Models
{
    public class DoctorExpertiseModel
    {
        [Display(Name = "Doctor Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Doctor Name Required")]
        public string DoctorName { get; set; } 

        [Display(Name = "Doctor Expertise")]
        public int ExpertiseCode { get; set; }  //ID of Expertise selected
    }
}
