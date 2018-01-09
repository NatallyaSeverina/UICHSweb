using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class EmergrncySituationVMListRepository : IEmergrncySituationVMListRepository
    {
        DAL.ModelDB context = new DAL.ModelDB();
        public IEnumerable<EmergrncySituationVMList> GetEmergencyListByDate(DateTime _date)
        {

            return context.EmergencySituations.ToArray().Where(cl => (cl.dateOfEmergency == _date || cl.dateOfEmergency == _date.AddDays(1))).Select((DAL.EmergencySituation em) =>
            {

                return new Model.EmergrncySituationVMList
                {
                    EmergencyId = em.emergencyID,
                    DateOfEmergency = em.dateOfEmergency,
                    Region = em.region,
                    Neighborhood = em.neighborhood,
                    PopylatedLocality = em.popylatedLocality,
                    Kind = em.kind,
                    RegistrationTime = em.ReceivedMessage.timeOfReceive,
                    DescriptionOfEmergency = em.descriptionOfEmergency,
                    ToRegistration = em.toRegistration,
                    ToReport = em.toReport,
                    Perished=(em.Victim??new DAL.Victim()).perished??0,
                    PerishedChildren= (em.Victim ?? new DAL.Victim()).perishedChildren ?? 0
                };


            }).Where(cl => ((cl.DateOfEmergency == _date && cl.RegistrationTime >= new TimeSpan(06, 00, 00)) || (cl.DateOfEmergency == _date.AddDays(1) && cl.RegistrationTime < new TimeSpan(06, 00, 00))));
        }
    }
}
