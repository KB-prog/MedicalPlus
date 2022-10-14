using MedicalApplication.Data.IDAO;
using MedicalApplication.Data.Model.Domain;
using MedicalApplication.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Data.DAO
{
    public class DoctorDAO : IDoctorDAO
    {
        private MedicalPlusContext context;
        public DoctorDAO()
        {
            context = new MedicalPlusContext();
        }

        public void AddAppointmentToCollection(Appointment appointment, Doctor doctor, MedicalPlusContext context) 
        {
            context.Doctors.Find(doctor.DoctorID).Appointments.Add(appointment);
        }

        public void AddDoctor(Doctor doctor, MedicalPlusContext context)
        {
            context.Doctors.Add(doctor);
        }
        
        public void DeleteDoctor(Doctor doctor, MedicalPlusContext context)
        {
            context.Doctors.Remove(doctor);
        }

        public IList<Appointment> GetAppointments(int id, MedicalPlusContext context)
        {
            context.Doctors.Include(m => m.Appointments).ToList();
            return context.Appointments.ToList();
        }

        public Doctor GetDoctor(int id, MedicalPlusContext context)
        {
            context.Doctors.Include(g => g.Appointments).ToList();
            return context.Doctors.Find(id);
        }

        public Doctor GetDoctor(Appointment appointment, MedicalPlusContext context)
        {
            context.Doctors.Include(g => g.Appointments).ToList();
            return context.Doctors.Find(appointment);
        }

        public IList<Doctor> GetDoctors(MedicalPlusContext context)
        {
            context.Doctors.Include(g => g.Appointments).ToList();
            return context.Doctors.ToList();
        }

        public IList<Doctor> GetDoctorsAppointments(MedicalPlusContext context)
        {
            context.Doctors.Include(g => g.Appointments).ToList();
            return context.Doctors.ToList();
        }

        public void RemoveAppointmentFromCollection(Appointment appointment, Doctor doctor, MedicalPlusContext context)
        {
            context.Doctors.Find(doctor.DoctorID).Appointments.Remove(appointment);
        }
    }
}
