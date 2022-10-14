using MedicalApplication.Data.Model.Domain;
using MedicalApplication.Data.Repository;
using MedicalApplication.Services.IService;
using MedicalApplication.Services.Models;
using MedicalApplication.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        // GET: User
        private MedicalPlusContext context;
        IUserService userService;

        public UserController()
        {
            context = new MedicalPlusContext();
            userService = new UserService();
        }

        // GET: User
        public ActionResult GetUsers()
        {
            return View(userService.GetUsers());
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserModel userModel)
        {

            userService.AddUser(userModel);
            return RedirectToAction("GetUsers", "User");
        }

        public ActionResult GetUser(string id)
        {
            return View(userService.GetUser(id));
        }

        public ActionResult GetAppointments(int id)
        {
            IList<Appointment> appointment = userService.GetAppointments(id).ToList();
            return View(appointment); 
        }
    }
}