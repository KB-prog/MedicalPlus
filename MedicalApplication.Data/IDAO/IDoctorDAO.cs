using MedicalApplication.Data.Model.Domain;
using MedicalApplication.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Data.IDAO
{
    public interface IDoctorDAO
    {
        IList<Doctor> GetDoctors(MedicalPlusContext context);
        IList<Doctor> GetDoctorsAppointments(MedicalPlusContext context);
        Doctor GetDoctor(int id, MedicalPlusContext context);
        IList<Appointment> GetAppointments(int id, MedicalPlusContext context);
        void AddAppointmentToCollection(Appointment appointment, Doctor doctor, MedicalPlusContext context);
        Doctor GetDoctor(Appointment appointment, MedicalPlusContext context);
        void RemoveAppointmentFromCollection(Appointment appointment, Doctor doctor, MedicalPlusContext context);
        void AddDoctor(Doctor doctor, MedicalPlusContext context);
        void DeleteDoctor(Doctor doctor, MedicalPlusContext context); 
    }
}
