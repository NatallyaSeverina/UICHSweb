using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IEmergencySituationVMCRUDRepository
    {
        Model.EmergencySituationVMCRUD GetEmergencySituationByID(int _id);
        void DeleteEmergencySituation(int _id);
        void AddNewEmergency(EmergencySituationVMCRUD _emergencySituation);
        void EditEmergency(EmergencySituationVMCRUD _emergencySituation);
    }
}
