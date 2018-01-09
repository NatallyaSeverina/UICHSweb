using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace Repository
{
    public class EmergencySituationVMCRUDRepository : IEmergencySituationVMCRUDRepository
    {
        DAL.ModelDB context = new DAL.ModelDB();
        public void AddNewEmergency(EmergencySituationVMCRUD _emergencySituation)
        {
            DAL.EmergencySituation emergencySituation = new DAL.EmergencySituation
            {
                dateOfEmergency = _emergencySituation.DateOfEmergency,
                region = _emergencySituation.Region,
                neighborhood = _emergencySituation.Neighborhood,
                popylatedLocality = _emergencySituation.PopylatedLocality,
                adress = _emergencySituation.Adress,
                kind = _emergencySituation.Kind,
                checkOutTime = _emergencySituation.CheckOutTime,
                arrivalTime = _emergencySituation.ArrivalTime,
                descriptionOfEmergency = _emergencySituation.DescriptionOfEmergency,
                timeLocalisation = _emergencySituation.TimeLocalisation,
                timeLiquidation = _emergencySituation.TimeLiquidation,
                toRegistration = _emergencySituation.ToRegistration,
                toReport = _emergencySituation.ToReport,
                problematicIssues = _emergencySituation.ProblematicIssues,
                specialReport = _emergencySituation.SpecialReport,
                extraReportSuperiorOfficer = _emergencySituation.ExtraReportSuperiorOfficer,
                editLog = _emergencySituation.EditLog,
                ReceivedMessage = new DAL.ReceivedMessage
                {
                    timeMessageInROCHS = _emergencySituation.TimeMessageInROCHS,
                    timeOfReceive = _emergencySituation.TimeOfReceive,
                    dutyOfficerID = _emergencySituation.DutyOfficerId
                },
                Victim = new DAL.Victim
                {
                    perished = _emergencySituation.Perished,
                    perishedChildren = _emergencySituation.PerishedChildren,
                    injured = _emergencySituation.Injured,
                    injuredChildren = _emergencySituation.InjuredChildren,
                    evacuated = _emergencySituation.Evacuated,
                    evacuatedChildren = _emergencySituation.EvacuatedChildren,
                    rescued = _emergencySituation.Rescued,
                    rescuedChildren = _emergencySituation.RescuedChildren,
                }


            };

            foreach (Model.SuperiorOfficer s in _emergencySituation.SuperiorOfficers)
            {
                emergencySituation.SuperiorOfficers.Add(
                    new DAL.SuperiorOfficer
                    {
                        position = s.Position,
                        statusOfReport = s.StatusOfReport,
                        timeReport = s.TimeReport
                    });

            }
            context.EmergencySituations.Add(emergencySituation);

            context.SaveChanges();


            foreach (var v in _emergencySituation.Vechicle2Emergency)
                context.AddVechicle2Emergency(emergencySituation.emergencyID, v.VechicleName.ToUpper(), v.CountVechicle);
            context.SaveChanges();
        }

        public void DeleteEmergencySituation(int _id)
        {
            context.EmergencySituations.Remove(context.EmergencySituations.Find(_id));
            context.ReceivedMessages.Remove(context.ReceivedMessages.Find(_id));
            context.Victims.Remove(context.Victims.Find(_id));
            foreach (var v in context.Vechicle2Emergency.Where(cl => (cl.emergencyID == _id)))
            {
                context.Vechicle2Emergency.Remove(v);
            }
            foreach (var v in context.SuperiorOfficers.Where(cl => (cl.emergencyID == _id)))
            {
                context.SuperiorOfficers.Remove(v);
            }
            context.SaveChanges();
        }

        public void EditEmergency(EmergencySituationVMCRUD _emergencySituation)
        {
            DAL.EmergencySituation em = context.EmergencySituations.Find(_emergencySituation.EmergencyId);
            em.dateOfEmergency = _emergencySituation.DateOfEmergency;
            em.region = _emergencySituation.Region;
            em.neighborhood = _emergencySituation.Neighborhood;
            em.popylatedLocality = _emergencySituation.PopylatedLocality;
            em.adress = _emergencySituation.Adress;
            em.kind = _emergencySituation.Kind;
            em.checkOutTime = _emergencySituation.CheckOutTime;
            em.arrivalTime = _emergencySituation.ArrivalTime;
            em.descriptionOfEmergency = _emergencySituation.DescriptionOfEmergency;
            em.timeLocalisation = _emergencySituation.TimeLocalisation;
            em.timeLiquidation = _emergencySituation.TimeLiquidation;
            em.toRegistration = _emergencySituation.ToRegistration;
            em.toReport = _emergencySituation.ToReport;
            em.problematicIssues = _emergencySituation.ProblematicIssues;
            em.specialReport = _emergencySituation.SpecialReport;
            em.extraReportSuperiorOfficer = _emergencySituation.ExtraReportSuperiorOfficer;
            em.editLog = _emergencySituation.EditLog;

            DAL.ReceivedMessage m = context.ReceivedMessages.Find(_emergencySituation.EmergencyId);
            m.timeMessageInROCHS = _emergencySituation.TimeMessageInROCHS;
            m.timeOfReceive = _emergencySituation.TimeOfReceive;


            DAL.Victim v = context.Victims.Find(_emergencySituation.EmergencyId);
            v.perished = _emergencySituation.Perished;
            v.perishedChildren = _emergencySituation.PerishedChildren;
            v.injured = _emergencySituation.Injured;
            v.injuredChildren = _emergencySituation.InjuredChildren;
            v.evacuated = _emergencySituation.Evacuated;
            v.evacuatedChildren = _emergencySituation.EvacuatedChildren;
            v.rescued = _emergencySituation.Rescued;
            v.rescuedChildren = _emergencySituation.RescuedChildren;

            foreach (var s in context.SuperiorOfficers.Where(cl => (cl.emergencyID == _emergencySituation.EmergencyId)))
            {
                context.SuperiorOfficers.Remove(s);
            }

            foreach (Model.SuperiorOfficer s in _emergencySituation.SuperiorOfficers)
            {
                context.SuperiorOfficers.Add(
                    new DAL.SuperiorOfficer
                    {
                        emergencyID = s.EmergencyID,
                        position = s.Position,
                        statusOfReport = s.StatusOfReport,
                        timeReport = s.TimeReport
                    });

            }

            foreach (var ve in context.Vechicle2Emergency.Where(cl => (cl.emergencyID == _emergencySituation.EmergencyId)))
            {
                context.Vechicle2Emergency.Remove(ve);
            }
            context.SaveChanges();
            foreach (var vec in _emergencySituation.Vechicle2Emergency)
            {
                context.AddVechicle2Emergency(_emergencySituation.EmergencyId, vec.VechicleName.ToUpper(), vec.CountVechicle);
            }

            context.SaveChanges();
        }

        public Model.EmergencySituationVMCRUD GetEmergencySituationByID(int _id)
        {
            var em = context.EmergencySituations.Find(_id);
            Model.EmergencySituationVMCRUD emergencySituation=new Model.EmergencySituationVMCRUD             
            {
                EmergencyId = em.emergencyID,
                DateOfEmergency = em.dateOfEmergency,
                Region = em.region,
                Neighborhood = em.neighborhood,
                PopylatedLocality = em.popylatedLocality,
                Adress = em.adress,
                Kind = em.kind,
                CheckOutTime = em.checkOutTime,
                ArrivalTime = em.arrivalTime,
                DescriptionOfEmergency = em.descriptionOfEmergency,
                TimeLiquidation = em.timeLiquidation,
                TimeLocalisation = em.timeLocalisation,
                ToRegistration = em.toRegistration,
                ToReport = em.toReport,
                ProblematicIssues = em.problematicIssues,
                SpecialReport = em.specialReport,
                ExtraReportSuperiorOfficer = em.extraReportSuperiorOfficer,
                EditLog = em.editLog
            };
            var mes = context.EmergencySituations.Find(_id).ReceivedMessage;
            emergencySituation.TimeMessageInROCHS = mes.timeMessageInROCHS;
            emergencySituation.TimeOfReceive = mes.timeOfReceive;
            emergencySituation.DutyOfficerId = mes.dutyOfficerID;
            emergencySituation.NameDutyOfficer = context.DutyOfficers.Find(mes.dutyOfficerID).nameDutyOfficer;
            foreach (var s in context.EmergencySituations.Find(_id).SuperiorOfficers)
            {
                emergencySituation.SuperiorOfficers.Add(
                    new Model.SuperiorOfficer
                {
                    Position = s.position,
                    EmergencyID = s.emergencyID,
                    StatusOfReport = s.statusOfReport,
                    TimeReport = s.timeReport
                });

            }
            foreach (var v in context.Vechicle2Emergency.Where(cl => (cl.emergencyID == _id)))
            {
                emergencySituation.Vechicle2Emergency.Add(new Model.Vechicle2Emergency
                {
                    CountVechicle = v.countVechicle,
                    EmergencyID = v.emergencyID,
                    VechicleID = v.vechicleID,
                    VechicleName=context.Vechicles.Find(v.vechicleID).nameVechicle


                });

            }
            var vic = context.EmergencySituations.Find(_id).Victim;
            emergencySituation.Perished = vic.perished;
            emergencySituation.PerishedChildren = vic.perishedChildren;
            emergencySituation.Injured = vic.injured;
            emergencySituation.InjuredChildren = vic.injuredChildren;
            emergencySituation.Evacuated = vic.evacuated;
            emergencySituation.EvacuatedChildren = vic.evacuatedChildren;
            emergencySituation.Rescued = vic.rescued;
            emergencySituation.RescuedChildren = vic.rescuedChildren;
            return emergencySituation;

        }
    }
}
