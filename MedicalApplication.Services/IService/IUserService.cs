using MedicalApplication.Data.Model.Domain;
using MedicalApplication.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Services.IService
{
    public interface IUserService
    {
        IList<User> GetUsers();
        void AddUser(UserModel userModel); 
        User GetUser(string id);
        IList<Appointment> GetAppointments(int id); 
    }
}
