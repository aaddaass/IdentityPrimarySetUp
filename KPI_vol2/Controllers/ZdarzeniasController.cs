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
    public class ZdarzeniasController : Controller
    {
        private readonly IZdarzenie _zdarzenie;
        private readonly IStatus _status;

        public ZdarzeniasController(IZdarzenie zdarzenie, IStatus status)
        {
            _zdarzenie = zdarzenie;
            _status = status;
        }

        // GET: Zdarzenias
        public ViewResult Index()
        {
              return View( _zdarzenie.GetAll());
        }

        // GET: Zdarzenias/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Zdarzenia zdarzenia=_zdarzenie.GetZdarzenia(id);
            if (id == null)
            {
                Response.StatusCode = 404;
                return View("UserNotFound",id);
            }

           return View(zdarzenia);
        }

        // GET: Zdarzenias/Create
        public IActionResult Create()
        {
            
            ViewBag.StatusList = new SelectList(_status.GetAll(), "IdStatus", "Name");
            return View();
        }

        // POST: Zdarzenias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult Create(Zdarzenia zdarzenia)
        {
            
            ViewBag.StatusList = new SelectList(_status.GetAll(), "IdStatus", "Name");

            Zdarzenia newzdarzenie=_zdarzenie.AddZdarzenie(zdarzenia);
                
                return RedirectToAction("details",new {id=newzdarzenie.Id});
            
            
        }

        // GET: Zdarzenias/Edit/5
        public ViewResult Edit(int id)
        {
            Zdarzenia zdarzenia = _zdarzenie.GetZdarzenia(id);
            return View(zdarzenia);
        }

        // POST: Zdarzenias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( Zdarzenia zdarzenia)
        {
           

            if (ModelState.IsValid)
            {
               
                    _zdarzenie.UpdateZdarzenie(zdarzenia);
                    
             
            }
            return RedirectToAction("details", new {id=zdarzenia.Id});
        }

        // GET: Zdarzenias/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Zdarzenia == null)
        //    {
        //        return NotFound();
        //    }

        //    var zdarzenia = await _context.Zdarzenia
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (zdarzenia == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(zdarzenia);
        //}

        //// POST: Zdarzenias/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Zdarzenia == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Zdarzenia'  is null.");
        //    }
        //    var zdarzenia = await _context.Zdarzenia.FindAsync(id);
        //    if (zdarzenia != null)
        //    {
        //        _context.Zdarzenia.Remove(zdarzenia);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ZdarzeniaExists(int id)
        //{
        //  return _context.Zdarzenia.Any(e => e.Id == id);
        //}
    }
}
