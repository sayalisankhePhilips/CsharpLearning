using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeAPI.Models
{
    public class PatientInfoModel
    {
        public PatientInfoModel()
        {

        }
        public string MRN { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string phoneNumber { get; set; }

    }
}
