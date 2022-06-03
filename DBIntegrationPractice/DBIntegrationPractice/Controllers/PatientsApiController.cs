using DBIntegrationPractice.DBContexts;
using DBIntegrationPractice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DBIntegrationPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsApiController : ControllerBase
    {
        PatientsDataContext _dataContext;

        public PatientsApiController(PatientsDataContext patientsDataContext)
        {
            this._dataContext = patientsDataContext;
        }
        // GET: api/<PatientsApiController>
        [HttpGet]
        public IEnumerable<PatientsModel> GetAll()
        {
            return this._dataContext.Patients.ToList();
        }

        // GET api/<PatientsApiController>/5
        [HttpGet("{id}")]
        public PatientsModel GetPatientById(string id)
        {
            return this._dataContext.Patients.Where(item => item.PatientModelID == id).First();
        }

        // POST api/<PatientsApiController>
        [HttpPost]
        public void AddNewPatient([FromBody] PatientsModel newPatient)
        {
            this._dataContext.Patients.Add(newPatient);
            this._dataContext.SaveChanges();
        }

        // PUT api/<PatientsApiController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] PatientsModel updatePatient)
        {
            PatientsModel toBeUpdated = this._dataContext.Patients.Find(id);
            this._dataContext.Entry(toBeUpdated).CurrentValues.SetValues(updatePatient);
            this._dataContext.SaveChanges();
        }

        // DELETE api/<PatientsApiController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
           PatientsModel toBeRemoved =  this._dataContext.Patients.Where(item => item.PatientModelID == id).First();
            this._dataContext.Patients.Remove(toBeRemoved);
            this._dataContext.SaveChanges();
        }
    }
}
