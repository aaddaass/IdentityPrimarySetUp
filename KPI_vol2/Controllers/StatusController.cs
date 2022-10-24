using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KPI_vol2.Data;
using KPI_vol2.Models;
using KPI_vol2.Interface;

namespace KPI_vol2.Controllers
{
    public class StatusController : Controller
    {
        private readonly IStatus _status;

        public StatusController(IStatus status)
        {
            _status = status;
        }

        // GET: Status
        public ActionResult Index()
        {
              return View(_status.GetAllStatus());
        }

      

        // GET: Status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Status status)
        {
            if(ModelState.IsValid)
            {
                Status newstatus = new Status
                {
                    NazwaStatus = status.NazwaStatus
                };
                _status.AddStatus(status);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Status/Edit/5
        public ActionResult Edit(int id)
        {
            Status status = _status.GetStatus(id);
            return View(status);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Status status)
        {
            if (ModelState.IsValid)
            {
                _status.UpdateStatus(status);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Status/Delete/5
        public ActionResult Delete(int id)
        {
           var status=_status.GetStatus(id);    
            return View();
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _status.DeleteStatus(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }

        //private bool StatusExists(int id)
        //{
        //  return _context.Status.Any(e => e.IdZdarzenia == id);
        //}
    }
}
