using MedicalApplication.Data.Model.Domain;
using MedicalApplication.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Services.IService
{
    public interface IAppointmentService
    {
        Appointment GetAppointment(int id);
        void AddAppointment(AppointmentDoctorModel appointmentDoctorModel, string userId);  
        IList<Appointment> GetAppointments();
        void DeleteAppointment(int appointmentId, string userId); 
    }
}
