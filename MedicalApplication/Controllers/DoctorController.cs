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
    [Authorize(Roles = "Admin, Doctor")]
    public class DoctorController : Controller
    {
        private MedicalPlusContext context;
        IDoctorService doctorService;

        public DoctorController()
        {
            context = new MedicalPlusContext();
            doctorService = new DoctorService();
        }

        // GET: Doctor
        public ActionResult GetDoctors()
        {
            return View(doctorService.GetDoctors());
        }

        public ActionResult GetDoctor(int id)
        {
            return View(doctorService.GetDoctor(id));
        }

        public ActionResult GetAppointments(int id)
        {
            IList<Appointment> appointment = doctorService.GetAppointments(id).ToList();
            return View(appointment);
        }

        // GET: Doctor/Create
        public ActionResult AddDoctor()
        {
            Helper helper = new Helper();
            ViewBag.expertisesList = helper.GetExpertiseDropDown();
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        public ActionResult AddDoctor(DoctorExpertiseModel doctorExpertiseModel) 
        {
            try
            {

                doctorService.AddDoctor(doctorExpertiseModel);

                //Redirect to a different page/controller              
                return RedirectToAction("GetDoctors", "Doctor");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditDoctor(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = context.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: /Movies/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDoctor([Bind(Include = "DoctorID,DoctorName")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                context.Entry(doctor).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("GetDoctors", "Doctor");
            }
            return View(doctor);
        }

        public ActionResult DeleteDoctor(int doctorId) 
        {
            return View(doctorService.GetDoctor(doctorId));
        }


        [HttpPost]
        public ActionResult DeleteDoctor(int doctorId, Doctor doctor)
        {
            try
            {
                doctorService.DeleteDoctor(doctorId);

                return RedirectToAction("GetDoctors", "Doctor");

            }
            catch
            {
                return View();
            }
        }

        /***************This section allows for the doctor to edit the patients appointment to add notes about what was found and what has been done etc.********** */
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
                return RedirectToAction("GetDoctors", "Doctor");
            }
            return View(appointment);
        }
    }
}