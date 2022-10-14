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
    public class DoctorService : IDoctorService
    {
        private IDoctorDAO doctorDAO;
        private IExpertiseDAO expertiseDAO;
        private IAppointmentDAO appointmentDAO;
        public DoctorService() 
        {
            doctorDAO = new DoctorDAO();
            expertiseDAO = new ExpertiseDAO();
            appointmentDAO = new AppointmentDAO();
        }

        public void AddDoctor(DoctorExpertiseModel doctorExpertiseModel)
        {
            Doctor newDoctor= new Doctor() //Create new Doctor Object
            {
                DoctorName = doctorExpertiseModel.DoctorName,
                
            };
            using (var context = new MedicalPlusContext())
            {
                //Context is created
                doctorDAO.AddDoctor(newDoctor, context); // Add Doctor
                Expertise expertise = expertiseDAO.GetExpertise(doctorExpertiseModel.ExpertiseCode, context);
                expertiseDAO.AddDoctorToCollection(newDoctor, expertise, context);
                context.SaveChanges();
            }
        }

        public void DeleteDoctor(int doctorId)
        {
            using (var context = new MedicalPlusContext())
            {

                Doctor doctor = doctorDAO.GetDoctor(doctorId, context);              
                doctorDAO.DeleteDoctor(doctor, context);               
                context.SaveChanges();
            }
        }

        public IList<Appointment> GetAppointments(int id)
        {
            using (var context = new MedicalPlusContext())
            {
                return doctorDAO.GetAppointments(id, context);
            }
        }

        public Doctor GetDoctor(int id)
        {
            using (var context = new MedicalPlusContext())
            {
                return doctorDAO.GetDoctor(id, context);
            }
        }

        //public Doctor GetDoctor(Appointment appointment)
        //{
        //    using (var context = new MedicalPlusContext())
        //    {
                
        //    }
        //}

        public IList<Doctor> GetDoctors()
        {
            using (var context = new MedicalPlusContext())
            {
                return doctorDAO.GetDoctors(context);
            }
        }

        public IList<Doctor> GetDoctorsAppointments()
        {
            using (var context = new MedicalPlusContext())
            {
                return doctorDAO.GetDoctorsAppointments(context);
            }
        }

    }
}
