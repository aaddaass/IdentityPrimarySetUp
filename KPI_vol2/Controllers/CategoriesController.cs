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
    public class CategoriesController : Controller
    {
        private readonly ICategories _Categories;

        public CategoriesController(ICategories Categories)
        {
            _Categories = Categories;
        }

        // GET: Categories
        public ActionResult Index()
        {
            return View(_Categories.GetAllCategories());
        }



        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categories Categories)
        {
            if (ModelState.IsValid)
            {
                Categories newCategories = new Categories
                {
                    Name = Categories.Name
                };
                _Categories.AddCategories(Categories);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            Categories Categories = _Categories.GetCategories(id);
            return View(Categories);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categories Categories)
        {
            if (ModelState.IsValid)
            {
                _Categories.UpdateCategories(Categories);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            var Categories = _Categories.GetCategories(id);
            return View();
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _Categories.DeleteCategories(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }

        //private bool CategoriesExists(int id)
        //{
        //  return _context.Categories.Any(e => e.IdZdarzenia == id);
        //}
    }
}
