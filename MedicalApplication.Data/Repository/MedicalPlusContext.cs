using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MedicalApplication.Data.Model.Domain;

namespace MedicalApplication.Data.Repository
{
    public class MedicalPlusContext : DbContext
    {
        public MedicalPlusContext() : base("MedicalPlusContext")
        {
            Database.SetInitializer(new MedicalPlusInitialiser());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Expertise> Expertises { get; set; }


    }
}

