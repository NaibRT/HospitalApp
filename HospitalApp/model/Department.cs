using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.model
{
   public class Department
    {
        public Department()
        {
            Doctors = new HashSet<Doctor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Doctor> Doctors { get; set; }

    }
}
