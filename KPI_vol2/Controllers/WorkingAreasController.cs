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
    public class WorkingAreasController : Controller
    {
        private readonly IWorkingAreas _WorkingAreas;

        public WorkingAreasController(IWorkingAreas WorkingAreas)
        {
            _WorkingAreas = WorkingAreas;
        }

        // GET: WorkingAreas
        public ActionResult Index()
        {
            return View(_WorkingAreas.GetAllWorkingAreas());
        }



        // GET: WorkingAreas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkingAreas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkingAreas WorkingAreas)
        {
            if (ModelState.IsValid)
            {
                WorkingAreas newWorkingAreas = new WorkingAreas
                {
                    Name = WorkingAreas.Name
                };
                _WorkingAreas.AddWorkingAreas(WorkingAreas);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: WorkingAreas/Edit/5
        public ActionResult Edit(int id)
        {
            WorkingAreas WorkingAreas = _WorkingAreas.GetWorkingAreas(id);
            return View(WorkingAreas);
        }

        // POST: WorkingAreas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WorkingAreas WorkingAreas)
        {
            if (ModelState.IsValid)
            {
                _WorkingAreas.UpdateWorkingAreas(WorkingAreas);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: WorkingAreas/Delete/5
        public ActionResult Delete(int id)
        {
            var WorkingAreas = _WorkingAreas.GetWorkingAreas(id);
            return View();
        }

        // POST: WorkingAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _WorkingAreas.DeleteWorkingAreas(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }

        //private bool WorkingAreasExists(int id)
        //{
        //  return _context.WorkingAreas.Any(e => e.IdZdarzenia == id);
        //}
    }
}
