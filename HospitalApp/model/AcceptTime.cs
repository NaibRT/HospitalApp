using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.model
{
    public class AcceptTime
    {
        public AcceptTime()
        {
            Doctors = new HashSet<Doctor>();
        }
        public int Id { get; set; }
        public string Time { get; set; }
        public bool TimeStatus { get; set; }


        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
