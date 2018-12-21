using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApp.model
{
   public class Ward
    {
        public Ward()
        {
            Rooms = new HashSet<Room>();
        }
        public int Id { get; set; }
        public int Number { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
