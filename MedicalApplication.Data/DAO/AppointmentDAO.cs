using MedicalApplication.Data.IDAO;
using MedicalApplication.Data.Model.Domain;
using MedicalApplication.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Data.DAO
{
    public class AppointmentDAO : IAppointmentDAO
    {
        private MedicalPlusContext context;
        public AppointmentDAO() 
        {
            context = new MedicalPlusContext();
        }

        public void AddAppointment(Appointment appointment, MedicalPlusContext context) 
        {
            context.Users.Include(g => g.Appointments).ToList();
            context.Appointments.Add(appointment);
        }

        public void DeleteApplication(Appointment appointment, MedicalPlusContext context)
        {
            context.Appointments.Remove(appointment);
        }

        public Appointment GetAppointment(int id, MedicalPlusContext context)
        {
            context.Users.Include(g => g.Appointments).ToList();
            return context.Appointments.Find(id);
        }

        public IList<Appointment> GetAppointments(MedicalPlusContext context)
        {
            context.Users.Include(g => g.Appointments).ToList();
            return context.Appointments.ToList();
        }
    }
}
