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
    public class PrioritiesController : Controller
    {
        private readonly IPriorities _Priorities;

        public PrioritiesController(IPriorities Priorities)
        {
            _Priorities = Priorities;
        }

        // GET: Priorities
        public ActionResult Index()
        {
            return View(_Priorities.GetAllPriorities());
        }



        // GET: Priorities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Priorities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Priorities Priorities)
        {
            if (ModelState.IsValid)
            {
                Priorities newPriorities = new Priorities
                {
                    Name = Priorities.Name
                };
                _Priorities.AddPriorities(Priorities);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Priorities/Edit/5
        public ActionResult Edit(int id)
        {
            Priorities Priorities = _Priorities.GetPriorities(id);
            return View(Priorities);
        }

        // POST: Priorities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Priorities Priorities)
        {
            if (ModelState.IsValid)
            {
                _Priorities.UpdatePriorities(Priorities);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Priorities/Delete/5
        public ActionResult Delete(int id)
        {
            var Priorities = _Priorities.GetPriorities(id);
            return View();
        }

        // POST: Priorities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _Priorities.DeletePriorities(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }

        //private bool PrioritiesExists(int id)
        //{
        //  return _context.Priorities.Any(e => e.IdZdarzenia == id);
        //}
    }
}
