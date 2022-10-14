using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Data.Model.Domain
{
    public class Appointment
    {
        [Key]
        [Required]
        public int AppointmentID { get; set; } 
        public DateTime AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string AppointmentReason { get; set; }
        public string AppointmentStatus { get; set; }
        public string DoctorsNotes { get; set; }
        //public virtual ICollection<Doctor> Doctors { get; set; }

    }
}
