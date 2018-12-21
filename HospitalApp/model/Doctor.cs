using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.model
{
   public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Speciality { get; set; }
        public string Password { get; set; }
        public string UserStatus { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
