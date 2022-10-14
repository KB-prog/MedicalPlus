using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Services.Models
{
    public class AppointmentDoctorModel
    {
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Appointment Date")]
        [Required(ErrorMessage = "Appointment Date Required")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; } 

        [Display(Name = "Appointment Time")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Appointment Time Required")]
        public string AppointmentTime { get; set; } 

        [Display(Name = "Appointment Reason")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Appointment Reason Required")]
        public string AppointmentReason { get; set; }

        [Display(Name = "Doctor")]
        public int DoctorCode { get; set; }  //ID of Doctor selected
    }
}
