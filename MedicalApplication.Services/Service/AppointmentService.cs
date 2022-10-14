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
    public class AppointmentService : IAppointmentService
    {
        private IDoctorDAO doctorDAO;
        private IAppointmentDAO appointmentDAO;
        private IUserDAO userDAO;
        public AppointmentService()
        {
            doctorDAO = new DoctorDAO();
            userDAO = new UserDAO();
            appointmentDAO = new AppointmentDAO();
        }

        public void AddAppointment(AppointmentDoctorModel appointmentDoctorModel, string userId) 
        {
            Appointment newAppointment = new Appointment() //Create new Appointment Object
            {
              AppointmentDate = appointmentDoctorModel.AppointmentDate,
              AppointmentTime = appointmentDoctorModel.AppointmentTime,
              AppointmentReason = appointmentDoctorModel.AppointmentReason,
              AppointmentStatus = "Upcoming",
              DoctorsNotes = "No Notes"

            };
            using (var context = new MedicalPlusContext())
            {
                //Context is created
                appointmentDAO.AddAppointment(newAppointment, context); // Add Appointment
                Doctor doctor = doctorDAO.GetDoctor(appointmentDoctorModel.DoctorCode, context); //Create Doctor Object
                doctorDAO.AddAppointmentToCollection(newAppointment, doctor, context); //Add Doctor to Collection of Genre
                userDAO.AddAppointmentToCollection(newAppointment, userId, context);
                context.SaveChanges();
            }
        }

        public void DeleteAppointment(int appointmentId, string userId)
        {
            using (var context = new MedicalPlusContext())
            {

                Appointment appointment = appointmentDAO.GetAppointment(appointmentId, context);
                IList<Doctor> AppointmentDoctorList = doctorDAO.GetDoctors(context);  
                foreach (Doctor item in AppointmentDoctorList)
                {
                    if (item.Appointments.Contains(appointment))
                    {
                        item.Appointments.Remove(appointment);
                    }
                }
                userDAO.RemoveAppointmentFromCollection(appointment, userId, context);
                appointmentDAO.DeleteApplication(appointment, context);
                context.SaveChanges();
            }
        }

        public Appointment GetAppointment(int id)
        {
            using (var context = new MedicalPlusContext())
            {
                return appointmentDAO.GetAppointment(id, context);
            }
        }

        public IList<Appointment> GetAppointments()
        {
            using (var context = new MedicalPlusContext())
            {
                return appointmentDAO.GetAppointments(context);
            }
        }
    }
}
