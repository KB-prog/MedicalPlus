using MedicalApplication.Data.Model.Domain;
using MedicalApplication.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Data.IDAO
{
    public interface IUserDAO
    {
        IList<User> GetUsers(MedicalPlusContext context);
        User GetUser(Appointment appointment, MedicalPlusContext context); 
        User GetUser(string id, MedicalPlusContext context);
        IList<Appointment> GetAppointments(int id, MedicalPlusContext context);
        void AddAppointmentToCollection(Appointment appointment, string userId, MedicalPlusContext context);
        void RemoveAppointmentFromCollection(Appointment appointment, string userId, MedicalPlusContext context);
        void AddUser(User user, MedicalPlusContext context);
    }
}
