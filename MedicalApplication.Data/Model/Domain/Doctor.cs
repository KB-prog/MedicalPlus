using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Data.Model.Domain
{
    public class Doctor
    {
        [Key]
        [Required]
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; } 
    }
}
