using Pharmacy.DataAccess.Repository;
using Pharmacy.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace PharmacyWeb.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class PatientsController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public PatientsController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public IEnumerable<Patient> Get()
        {
            return _unitOfWork.Patients.GetAll();
        }

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

        [ValidateAntiForgeryToken]
        public void Post([FromBody] Patient value)
        {
            if (value != null)
            {
                _unitOfWork.Patients.Add(value);
            }
        }

        public void Put(int id, [FromBody] Patient value)
        {
            if (id == 0)
            {
                NotFound();
            }
            var patientsFromDbFirst = _unitOfWork.Patients.GetFirstOrDefault(x => x.Id == id);
            
            if (patientsFromDbFirst == null)
            {
                NotFound();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Patients.Update(value);
            }
        }

        public void Delete(int id)
        {
            if (id == 0)
            {
                NotFound();
            }

            var patintsFromDbFirst = _unitOfWork.Patients.GetFirstOrDefault(x => x.Id == id);

            if (patintsFromDbFirst == null)
            {
                NotFound();
            }

            _unitOfWork.Patients.Remove(patintsFromDbFirst);
        }
    }
}