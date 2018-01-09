using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EmergencySituationVMCRUD
    {
        public EmergencySituationVMCRUD()
        {
            SuperiorOfficers = new List<SuperiorOfficer>();
            Vechicle2Emergency = new List<Vechicle2Emergency>();
        }
        public int EmergencyId { get; set; }

        public DateTime DateOfEmergency { get; set; }


        [StringLength(30)]
        public string Region { get; set; }

        [StringLength(30)]
        public string Neighborhood { get; set; }

        [StringLength(40)]
        public string PopylatedLocality { get; set; }

        [StringLength(40)]
        public string Adress { get; set; }

        [StringLength(60)]
        public string Kind { get; set; }

        public TimeSpan? CheckOutTime { get; set; }

        public TimeSpan? ArrivalTime { get; set; }

        [Required]
        public string DescriptionOfEmergency { get; set; }

        public TimeSpan? TimeLocalisation { get; set; }

        public TimeSpan? TimeLiquidation { get; set; }

        public bool ToRegistration { get; set; }

        public bool ToReport { get; set; }

        public string ProblematicIssues { get; set; }

        [Column(TypeName = "image")]
        public byte[] SpecialReport { get; set; }

        public string ExtraReportSuperiorOfficer { get; set; }

        public string EditLog { get; set; }

        public TimeSpan? TimeMessageInROCHS { get; set; }

        public TimeSpan TimeOfReceive { get; set; }

        public int DutyOfficerId { get; set; }
        public string NameDutyOfficer { get; set; }

       public List<SuperiorOfficer> SuperiorOfficers { get; set; }

       
        public List<Vechicle2Emergency> Vechicle2Emergency { get; set; }

        public int? Perished { get; set; }

        public int? Injured { get; set; }

        public int? Evacuated { get; set; }

        public int? Rescued { get; set; }

        public int? PerishedChildren { get; set; }

        public int? InjuredChildren { get; set; }

        public int? EvacuatedChildren { get; set; }

        public int? RescuedChildren { get; set; }
    }
}
