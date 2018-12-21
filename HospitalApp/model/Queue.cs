using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.model
{
   public class Queue
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int AcceptTimeId { get; set; }
        public virtual AcceptTime AcceptTime { get; set; }

        public string Review { get; set; }
    }
}
