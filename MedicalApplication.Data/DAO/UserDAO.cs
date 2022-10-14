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
    public class UserDAO : IUserDAO
    {
        private MedicalPlusContext context;
        public UserDAO()
        {
            context = new MedicalPlusContext();
        }

        public void AddAppointmentToCollection(Appointment appointment, string userId, MedicalPlusContext context)
        {
            context.Users.Find(userId).Appointments.Add(appointment);
        }

        public void AddUser(User user, MedicalPlusContext context)
        {
            context.Users.Include(g => g.Appointments).ToList();
            context.Users.Add(user);
        }

        public IList<Appointment> GetAppointments(int id, MedicalPlusContext context)
        {
            context.Users.Include(m => m.Appointments).ToList();
            return context.Appointments.ToList();
        }

        public User GetUser(Appointment appointment, MedicalPlusContext context)
        {
            context.Users.Include(g => g.Appointments).ToList();
            return context.Users.Find(appointment);
        }

        public User GetUser(string id, MedicalPlusContext context)
        {
            context.Users.Include(g => g.Appointments).ToList();
            return context.Users.Find(id);
        }

        public IList<User> GetUsers(MedicalPlusContext context)
        {
            return context.Users.ToList();
        }

        public void RemoveAppointmentFromCollection(Appointment appointment, string userId, MedicalPlusContext context)
        {
            context.Users.Find(userId).Appointments.Remove(appointment);
        }
    }
}
