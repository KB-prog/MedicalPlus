using MedicalApplication.Data.Model.Domain;
using MedicalApplication.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Services.IService
{
    public interface IDoctorService
    {
        IList<Doctor> GetDoctors();
        IList<Doctor> GetDoctorsAppointments();
        Doctor GetDoctor(int id);
        IList<Appointment> GetAppointments(int id);
        void AddDoctor(DoctorExpertiseModel doctorExpertiseModel);
        void DeleteDoctor(int doctorId); 
    }
}
