using MedicalApplication.Data.Model.Domain;
using MedicalApplication.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApplication.Data.IDAO
{
    public interface IAppointmentDAO
    {
        IList<Appointment> GetAppointments(MedicalPlusContext context);
        Appointment GetAppointment(int id, MedicalPlusContext context);
        void AddAppointment(Appointment appointment, MedicalPlusContext context);
        void DeleteApplication(Appointment appointment, MedicalPlusContext context);
    }
}
