using MedicalApplication.Data.IDAO;
using MedicalApplication.Data.Model.Domain;
using MedicalApplication.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Data.DAO
{
    public class ExpertiseDAO : IExpertiseDAO
    {
        private MedicalPlusContext context;
        public ExpertiseDAO() 
        {
            context = new MedicalPlusContext();
        }

        public void AddDoctorToCollection(Doctor doctor, Expertise expertise, MedicalPlusContext context)
        {
            context.Expertises.Find(expertise.ExpertiseID).Doctors.Add(doctor);
        }

        public void AddExpertise(Expertise expertise, MedicalPlusContext context)
        {
            context.Expertises.Add(expertise);
        }

        public void DeleteExpertise(Expertise expertise, MedicalPlusContext context)
        {
            context.Expertises.Remove(expertise);
        }

        public Expertise GetExpertise(int id, MedicalPlusContext context)
        {
            context.Expertises.Include(g => g.Doctors).ToList();
            return context.Expertises.Find(id);
        }

        public Expertise GetExpertise(Doctor doctor, MedicalPlusContext context)
        {
            context.Expertises.Include(g => g.Doctors).ToList();
            return context.Expertises.Find(doctor);
        }

        public IList<Expertise> GetExpertises(MedicalPlusContext context)
        {
            context.Expertises.Include(g => g.Doctors).ToList();
            return context.Expertises.ToList();
        }

        public void RemoveDoctorFromCollection(Doctor doctor, Expertise expertise, MedicalPlusContext context)
        {
            context.Expertises.Find(expertise.ExpertiseID).Doctors.Remove(doctor);
        }
    }
}
