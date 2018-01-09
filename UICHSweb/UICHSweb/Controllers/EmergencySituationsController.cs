using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UICHSweb.Controllers
{
    public class EmergencySituationsController : Controller
    {
        IEmergrncySituationVMListRepository repository;
        public EmergencySituationsController(IEmergrncySituationVMListRepository _repository)
        {
            repository = _repository;
        }
        public ActionResult List()
        {
            DateTime testDate = new DateTime(2017, 8, 21);
            return View(repository.GetEmergencyListByDate(testDate));
        }
        // GET: EmergencySituations
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmergencySituations/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmergencySituations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmergencySituations/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmergencySituations/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmergencySituations/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmergencySituations/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmergencySituations/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
