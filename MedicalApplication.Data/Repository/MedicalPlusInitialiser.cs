using MedicalApplication.Data.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MedicalApplication.Data.Repository
{
    public class MedicalPlusInitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<MedicalPlusContext>
    {
        protected override void Seed(MedicalPlusContext context)
        {
           

            // Creating User Objects
            User user1 = new User()
            {
                UserID = "kieron",
                UForename = "Kieron",
                USurname = "Bennett",
                UDOB = Convert.ToDateTime("12/11/1979"),
                UAddress = "12 Oak Road",
                UPostcode = "SK1 9WP",
                UEmail = "test@gmail.com",
                UPassword = "Test1!"
            };

            User user2 = new User()
            {
                UserID = "john",
                UForename = "John",
                USurname = "doe",
                UDOB = Convert.ToDateTime("12/11/1979"),
                UAddress = "12 Oak Road",
                UPostcode = "SK1 9WP",
                UEmail = "test1@gmail.com",
                UPassword = "Test1!"
            };

            User user3 = new User()
            {
                UserID = "admin",
                UForename = "Admin",
                USurname = "Admin",
                UDOB = Convert.ToDateTime("12/11/1979"),
                UAddress = "12 Oak Road",
                UPostcode = "SK1 9WP",
                UEmail = "admin@gmail.com",
                UPassword = "Admin1!"
            };
            context.Users.Add(user1); context.Users.Add(user2); context.Users.Add(user3);

            Appointment appointment1 = new Appointment()
            {
                AppointmentID = 1,
                AppointmentDate = Convert.ToDateTime("03/05/2022"),
                AppointmentTime = "9:45AM",
                AppointmentReason = "Sore Throat",
                AppointmentStatus = "Upcoming",
                DoctorsNotes = ""

            };
            Appointment appointment2 = new Appointment()
            {
                AppointmentID = 2,
                AppointmentDate = Convert.ToDateTime("03/05/2022"),
                AppointmentTime = "10:45AM",
                AppointmentReason = "Example Reason",
                AppointmentStatus = "Upcoming",
                DoctorsNotes = ""

            };
            Appointment appointment3 = new Appointment()
            {
                AppointmentID = 3,
                AppointmentDate = Convert.ToDateTime("03/05/2022"),
                AppointmentTime = "11:45AM",
                AppointmentReason = "Some Reason",
                AppointmentStatus = "Upcoming",
                DoctorsNotes = ""

            };
            context.Appointments.Add(appointment1); context.Appointments.Add(appointment2); context.Appointments.Add(appointment3);

            context.SaveChanges();
        }
    }
}
