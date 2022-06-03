using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DBIntegrationPractice.Models
{
    public class PatientsModel
    {
        [Key]
        public string PatientModelID { get; set; }
        public string Name { get; set; } = string.Empty; //default empty
    }
}
