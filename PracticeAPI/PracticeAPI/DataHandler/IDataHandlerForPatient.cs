using PracticeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeAPI.DataHandler
{
    public interface IDataHandlerForPatient
    {
        public PatientInfoModel CreatePatient(PatientInfoModel _newPatient);

        public IEnumerable<PatientInfoModel> GetAllPatients();

        public void UpdatePatient(string mrnNum, PatientInfoModel _updatePatient);

        public void DeletePatient(string mrnNum);
    }
}
