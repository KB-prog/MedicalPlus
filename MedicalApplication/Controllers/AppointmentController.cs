using Forest.Controllers;
using MedicalApplication.Data.Model.Domain;
using MedicalApplication.Data.Repository;
using MedicalApplication.Services.IService;
using MedicalApplication.Services.Models;
using MedicalApplication.Services.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MedicalApplication.Controllers
{
    [Authorize(Roles = "Patient")]
    public class AppointmentController : Controller
    {
        // GET: Appointment
        private IAppointmentService appointmentService;
        private MedicalPlusContext context;

        public AppointmentController()
        {
            appointmentService = new AppointmentService();
            context = new MedicalPlusContext();
        }
        // GET: Appointment
        public ActionResult GetAppointments() 
        {
            return View(appointmentService.GetAppointments());
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: Appointment/Create
        public ActionResult AddAppointment()
        {
            Helper helper = new Helper();
            ViewBag.doctorList = helper.GetDoctorDropDown();

            return View();
        }

        // POST: ApplicationAdmin/Create
        [HttpPost]
        public ActionResult AddAppointment(AppointmentDoctorModel appointmentDoctorModel)  
        {
            try
            {
                // 'kieron' is the userId of a User in User table
                appointmentService.AddAppointment(appointmentDoctorModel, "kieron");

                //Redirect to a different page/controller
                return RedirectToAction("GetAppointments", "Appointment");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = context.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: /Movies/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentID,AppointmentDate,AppointmentTime,AppointmentReason,AppointmentStatus,DoctorsNotes")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                context.Entry(appointment).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("GetAppointments", "Appointment");
            }
            return View(appointment);
        }

        // GET: ApplicationAdmin/Delete/5
        public ActionResult DeleteAppointment(int appointmentId)
        {
            Appointment appointment = new Appointment();
            if (context.Appointments.Any(x => x.AppointmentID == appointmentId))
            {
                return View(appointmentService.GetAppointment(appointmentId));
            }
            else
            {
                TempData["AlertMessage"] = "Something went wrong you, appointment was not cancelled";
                return RedirectToAction("GetAppointments", "Appointment");
            }
        }

        // POST: ApplicationAdmin/Delete/5
        [HttpPost]
        public ActionResult DeleteAppointment(int appointmentId, Appointment appointment) 
        {
            try
            {
                appointmentService.DeleteAppointment(appointmentId, "kieron");

                return RedirectToAction("GetAppointments", "Appointment");

            }
            catch
            {
                return View();
            }
        }
    }
}