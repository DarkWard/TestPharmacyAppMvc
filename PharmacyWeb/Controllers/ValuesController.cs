using Pharmacy.DataAccess.Repository;
using Pharmacy.DataAccess.Repository.IRepository;
using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PharmacyWeb.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ValuesController()
        {
            _unitOfWork = new UnitOfWork();
        }

        // GET api/values
        public IEnumerable<Patient> Get()
        {
            return _unitOfWork.Patients.GetAll();
        }

        // GET api/values/5
        public Patient Get(int id)
        {
            if (id == null || id == 0)
            {
                return null;
            }

            var patientsFromDbFirst = _unitOfWork.Patients.GetFirstOrDefault(x => x.Id == id);

            if (patientsFromDbFirst == null)
            {
                return null;
            }

            return patientsFromDbFirst;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
