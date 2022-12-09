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
    public class DepartmentsController : Controller
    {
        private readonly IDepartaments _Departments;

        public DepartmentsController(IDepartaments Departments)
        {
            _Departments = Departments;
        }

        // GET: Departments
        public ActionResult Index()
        {
            return View(_Departments.GetAllDepartments());
        }



        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Departments Departments)
        {
            if (ModelState.IsValid)
            {
                Departments newDepartments = new Departments
                {
                   Name = Departments.Name
                };
                _Departments.AddDepartments(Departments);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int id)
        {
            Departments Departments = _Departments.GetDepartments(id);
            return View(Departments);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Departments Departments)
        {
            if (ModelState.IsValid)
            {
                _Departments.UpdateDepartments(Departments);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int id)
        {
            var Departments = _Departments.GetDepartments(id);
            return View();
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _Departments.DeleteDepartments(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }

        //private bool DepartmentsExists(int id)
        //{
        //  return _context.Departments.Any(e => e.IdZdarzenia == id);
        //}
    }
}
