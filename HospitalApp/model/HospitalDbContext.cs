using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HospitalApp.model;

namespace HospitalApp.model
{
   public class HospitalDbContext:DbContext
    {
        public HospitalDbContext() : base("hospitalDB") { }

       public DbSet<AcceptTime> AcceptTimes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Ward> Wards { get; set; }
    }
}
