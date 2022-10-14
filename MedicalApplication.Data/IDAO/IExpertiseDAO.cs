using MedicalApplication.Data.Model.Domain;
using MedicalApplication.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Data.IDAO
{
    public interface IExpertiseDAO
    {
        void AddDoctorToCollection(Doctor doctor, Expertise expertise, MedicalPlusContext context);
        Expertise GetExpertise(int id, MedicalPlusContext context);
        IList<Expertise> GetExpertises(MedicalPlusContext context);
        Expertise GetExpertise(Doctor doctor, MedicalPlusContext context);
        void RemoveDoctorFromCollection(Doctor doctor, Expertise expertise, MedicalPlusContext context);
        void AddExpertise(Expertise expertise, MedicalPlusContext context);  
        void DeleteExpertise(Expertise expertise, MedicalPlusContext context);
    }
}
