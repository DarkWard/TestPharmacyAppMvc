using Pharmacy.DataAccess.Repository;
using Pharmacy.DataAccess.Repository.IRepository;
using Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmacyWeb.Controllers
{
    public class PharmaciesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PharmaciesController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            IEnumerable<Pharmacies> objPharmaciesList = _unitOfWork.Pharmacy.GetAll();
            return View(objPharmaciesList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pharmacies obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Pharmacy.Add(obj);
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

            var pharmaciesFromDbFirst = _unitOfWork.Pharmacy.GetFirstOrDefault(x => x.Id == id);

            if (pharmaciesFromDbFirst == null)
            {
                return HttpNotFound();
            }

            return View(pharmaciesFromDbFirst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pharmacies obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Pharmacy.Update(obj);
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

            var patintsFromDbFirst = _unitOfWork.Pharmacy.GetFirstOrDefault(x => x.Id == id);

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
            var obj = _unitOfWork.Pharmacy.GetFirstOrDefault(x => x.Id == id);

            if (obj == null)
            {
                return HttpNotFound();
            }

            _unitOfWork.Pharmacy.Remove(obj);
            return RedirectToAction("Index");
        }
    }
}