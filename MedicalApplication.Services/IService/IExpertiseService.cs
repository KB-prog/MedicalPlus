using MedicalApplication.Data.Model.Domain;
using MedicalApplication.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Services.IService
{
    public interface IExpertiseService
    {
        IList<Expertise> GetExpertises();
        Expertise GetExpertise(int id);
        void AddExpertise(ExpertiseModel expertiseModel);
        void DeleteExpertise(int expertiseId); 
    }
}
