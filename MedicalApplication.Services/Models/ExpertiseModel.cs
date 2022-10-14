using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Services.Models
{
    public class ExpertiseModel
    {
        [Display(Name = "Expertise Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Expertise Name Required")]
        public string ExpertiseName { get; set; }
         
        [Display(Name = "Expertise Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Expertise Description Required")]
        public string ExpertiseDescription { get; set; }  
    }
}
