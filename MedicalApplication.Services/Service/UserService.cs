using MedicalApplication.Data.DAO;
using MedicalApplication.Data.IDAO;
using MedicalApplication.Data.Model.Domain;
using MedicalApplication.Data.Repository;
using MedicalApplication.Services.IService;
using MedicalApplication.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Services.Service
{
    public class UserService : IUserService
    {
        private IUserDAO userDAO;
        public UserService()
        {
            userDAO = new UserDAO();
        }

        public void AddUser(UserModel userModel)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            User newUser = new User() //Create new User Object
            {
                UserID = finalString,
                UForename = userModel.UForename,
                USurname = userModel.USurname,
                UDOB = userModel.UDOB,
                UAddress = userModel.UAddress,
                UPostcode = userModel.UPostcode,
                UEmail = userModel.UEmail,
                UPassword = userModel.UPassword
            };
            using (var context = new MedicalPlusContext())
            {

                //Context is created
                userDAO.AddUser(newUser, context); // Add User
                context.SaveChanges();
            }
        }

        public IList<Appointment> GetAppointments(int id)
        {
            using (var context = new MedicalPlusContext())
            {
                return userDAO.GetAppointments(id, context);
            }
        }

        public User GetUser(string id)
        {
            using (var context = new MedicalPlusContext())
            {
                return userDAO.GetUser(id, context);
            }
        }

        public IList<User> GetUsers()
        {
            using (var context = new MedicalPlusContext())
            {
                return userDAO.GetUsers(context);
            }
        }
    }
}
