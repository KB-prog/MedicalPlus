using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Data.Model.Domain
{
    public class Expertise
    {
        [Key]
        [Required]
        public int ExpertiseID { get; set; }
        public string ExpertiseName { get; set; }
        public string ExpertiseDescription {get;set;}
        public virtual ICollection<Doctor> Doctors { get; set; } 
    }
}
