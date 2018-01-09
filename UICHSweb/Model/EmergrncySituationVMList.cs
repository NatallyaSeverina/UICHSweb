using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EmergrncySituationVMList
    {
       
        public int EmergencyId { get; set; }
        public DateTime DateOfEmergency { get; set; }
        public int? Perished { get; set; }
        public int? PerishedChildren { get; set; }
        public string Region { get; set; }
        public string Neighborhood { get; set; }
        public string PopylatedLocality { get; set; }
        public string Kind { get; set; }
        public TimeSpan? RegistrationTime { get; set; }
        public string DescriptionOfEmergency { get; set; }
        public bool ToRegistration { get; set; }
        public bool ToReport { get; set; }
      
    }
}
