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
    public class ExpertiseService : IExpertiseService
    {
        private IExpertiseDAO expertiseDAO; 
        public ExpertiseService()
        {
            expertiseDAO = new ExpertiseDAO();
        }

        public void AddExpertise(ExpertiseModel expertiseModel)
        {
            Expertise newExpertise = new Expertise() //Create new Expertise Object
            {
                ExpertiseName = expertiseModel.ExpertiseName,
                ExpertiseDescription = expertiseModel.ExpertiseDescription
            };
            using (var context = new MedicalPlusContext())
            {

                //Context is created
                expertiseDAO.AddExpertise(newExpertise, context); // Add Expertise
                context.SaveChanges();
            }
        }

        public void DeleteExpertise(int expertiseId)
        {
            using (var context = new MedicalPlusContext())
            {
                Expertise expertise = expertiseDAO.GetExpertise(expertiseId, context);

                expertiseDAO.DeleteExpertise(expertise, context);
                context.SaveChanges();
            }
        }
        public Expertise GetExpertise(int id)
        {
            using (var context = new MedicalPlusContext())
            {
                return expertiseDAO.GetExpertise(id, context);
            }
        }

        public IList<Expertise> GetExpertises()
        {
            using (var context = new MedicalPlusContext())
            {
                return expertiseDAO.GetExpertises(context);
            }
        }
    }
}
