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
    [Authorize(Roles = "Admin")]
    public class ExpertiseController : Controller
    {
        private MedicalPlusContext context;
        IExpertiseService expertiseService; 

        public ExpertiseController()
        {
            context = new MedicalPlusContext();
            expertiseService = new ExpertiseService();
        }

        // GET: Expertise
        public ActionResult GetExpertises() 
        {
            return View(expertiseService.GetExpertises());
        }

        // GET: ApplicationAdmin/Create
        public ActionResult AddExpertise() 
        {
            return View();
        }

        // POST: ApplicationAdmin/Create
        [HttpPost]
        public ActionResult AddExpertise(ExpertiseModel expertiseModel)
        {
            try
            {
                // 'mo' is the userId of a User in User table
                expertiseService.AddExpertise(expertiseModel);

                //Redirect to a different page/controller              
                return RedirectToAction("GetExpertises", "Expertise");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditExpertise(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expertise expertise = context.Expertises.Find(id);
            if (expertise == null)
            {
                return HttpNotFound();
            }
            return View(expertise);
        }

        // POST: /Movies/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditExpertise([Bind(Include = "ExpertiseID,ExpertiseName,ExpertiseDescription")] Expertise expertise) 
        {
            if (ModelState.IsValid)
            {
                context.Entry(expertise).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("GetExpertises", "Expertise");
            }
            return View(expertise);
        }

        public ActionResult DeleteExpertise(int expertiseId) 
        {
            return View(expertiseService.GetExpertise(expertiseId));       
        }

        
        [HttpPost]
        public ActionResult DeleteExpertise(int expertiseId, Expertise expertise)
        {
            try
            {
                expertiseService.DeleteExpertise(expertiseId);

                return RedirectToAction("GetExpertises", "Expertise");

            }
            catch
            {
                return View();
            }
        }
    }
}