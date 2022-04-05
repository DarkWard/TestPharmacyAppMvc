using Pharmacy.DataAccess.Repository;
using Pharmacy.DataAccess.Repository.IRepository;
using Pharmacy.Models;
using System.Collections.Generic;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace PharmacyWeb.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class PatientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            IEnumerable<Patient> objPatientsList = _unitOfWork.Patients.GetAll();
            return View(objPatientsList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Patients.Add(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }

            var patientsFromDbFirst = _unitOfWork.Patients.GetFirstOrDefault(x => x.Id == id);

            if (patientsFromDbFirst == null)
            {
                return HttpNotFound();
            }

            return View(patientsFromDbFirst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Patient obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Patients.Update(obj);
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return HttpNotFound();
            }

            var patintsFromDbFirst = _unitOfWork.Patients.GetFirstOrDefault(x => x.Id == id);

            if (patintsFromDbFirst == null)
            {
                return HttpNotFound();
            }

            return View(patintsFromDbFirst);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.Patients.GetFirstOrDefault(x => x.Id == id);

            if (obj == null)
            {
                return HttpNotFound();
            }

            _unitOfWork.Patients.Remove(obj);
            return RedirectToAction("Index");
        }
    }
}