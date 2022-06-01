using PracticeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeAPI.DataHandler
{
    public class PatientDataHandler : IDataHandlerForPatient
    {
        List<PatientInfoModel> _storage = new List<PatientInfoModel>();

        public PatientDataHandler()
        {
            _storage.AddRange(
                new PatientInfoModel[]
                {
                    new PatientInfoModel
                    {
                        MRN = "MRN100",
                        Name = "Tom",
                        Age = 34,
                        phoneNumber = "123456"
                    },
                    new PatientInfoModel
                    {
                        MRN = "MRN200",
                        Name = "Harry",
                        Age = 30,
                        phoneNumber = "123754456"
                    }
                }
                );
        }
        
           

        public PatientInfoModel CreatePatient(PatientInfoModel _newPatient)
        {
            _storage.Add(_newPatient);
            return _newPatient;

        }

        public IEnumerable<PatientInfoModel> GetAllPatients()
        {
            return this._storage;
        }

        public void UpdatePatient(string mrnNum, PatientInfoModel _updatePatient)
        {
            PatientInfoModel initialValue = _storage.Where(item => item.MRN == mrnNum).First();
            int index = _storage.IndexOf(initialValue);
            if (index != -1)
            {
                _storage[index] = _updatePatient;
            }
                
        }

        public void DeletePatient(string mrnNum)
        {
            PatientInfoModel dataToBeDeleted = _storage.Where(item => item.MRN == mrnNum).First();
            _storage.Remove(dataToBeDeleted);
        }
    }
}
