
using MedicalApplication.Data.Model.Domain;
using MedicalApplication.Services.IService;
using MedicalApplication.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forest.Controllers
{
    public class Helper
    {
        private IExpertiseService expertiseService;
        private IDoctorService doctorService;
        public Helper()
        {
            expertiseService = new ExpertiseService();
            doctorService = new DoctorService();
        }
         
        public List<SelectListItem> GetExpertiseDropDown()  
        {
            List<SelectListItem> expertiseList = new List<SelectListItem>(); 
            IList<Expertise> expertises = expertiseService.GetExpertises();
            
            foreach(var item in expertises)
            {
                expertiseList.Add
                    (
                        new SelectListItem()
                        {
                            Text = item.ExpertiseName,
                            Value = item.ExpertiseID.ToString(),
                            Selected = (item.ExpertiseName == (expertises[0].ExpertiseName) ? true : false)
                        }
                    );
            }
            return expertiseList;
        }
        public List<SelectListItem> GetDoctorDropDown() 
        {
            List<SelectListItem> doctorList = new List<SelectListItem>();
            IList<Doctor> doctors = doctorService.GetDoctors();

            foreach (var item in doctors)
            {
                doctorList.Add
                    (
                        new SelectListItem()
                        {
                            Text = item.DoctorName,
                            Value = item.DoctorID.ToString(),
                            Selected = (item.DoctorName == (doctors[0].DoctorName) ? true : false)
                        }
                    );
            }
            return doctorList;
        }
    }
}
