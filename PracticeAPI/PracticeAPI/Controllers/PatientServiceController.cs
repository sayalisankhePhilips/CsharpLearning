using Microsoft.AspNetCore.Mvc;
using PracticeAPI.DataHandler;
using PracticeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientServiceController : ControllerBase
    {
        IDataHandlerForPatient _repository;
        public PatientServiceController(IDataHandlerForPatient repository)
        {
            this._repository = repository;
        }
        // GET: api/<PatientServiceController>
        [HttpGet]
        public IEnumerable<PatientInfoModel> Get()
        {
            //return new string[] { "value1", "value2" };
            return _repository.GetAllPatients();
        }

        // GET api/<PatientServiceController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<PatientServiceController>
        [HttpPost]
        public PatientInfoModel Post([FromBody] PatientInfoModel _newPatient)
        {
            return _repository.CreatePatient(_newPatient);
        }

        // PUT api/<PatientServiceController>/5
        [HttpPut("{mrnNum}")]
        public void Put(string mrnNum, [FromBody] PatientInfoModel _patient)
        {
             _repository.UpdatePatient(mrnNum, _patient);
        }

        // DELETE api/<PatientServiceController>/5
        [HttpDelete("{mrnNum}")]
        public void Delete(string mrnNum)
        {
            _repository.DeletePatient(mrnNum);
        }
    }
}
