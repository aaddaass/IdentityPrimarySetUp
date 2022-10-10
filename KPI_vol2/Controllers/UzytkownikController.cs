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
    public class UzytkownikController : Controller
    {
        private readonly IUzytkownik _uzytkownik;

        public UzytkownikController(IUzytkownik uzytkownik)
        {
            _uzytkownik = uzytkownik;
        }

        // GET: Uzytkownik
        public ViewResult Index()
        {
            return View(_uzytkownik.GetAll());
        }

        // GET: Uzytkownik/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Uzytkownik uzytkownik = _uzytkownik.GetUzytkownik(id);
            if (uzytkownik == null)
            {
                Response.StatusCode = 404;
                return View("UserNotFound", id);
            }
            return View(uzytkownik);
        }

        // GET: Uzytkownik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uzytkownik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Uzytkownik uzytkownik)
        {
            Uzytkownik newuzytkownik = _uzytkownik.AddUzytkownik(uzytkownik);
            return RedirectToAction("Details", new {id=newuzytkownik.Id});
        }

        //// GET: Uzytkownik/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Uzytkowniks == null)
        //    {
        //        return NotFound();
        //    }

        //    var uzytkownik = await _context.Uzytkowniks.FindAsync(id);
        //    if (uzytkownik == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(uzytkownik);
        //}

        //// POST: Uzytkownik/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Department")] Uzytkownik uzytkownik)
        //{
        //    if (id != uzytkownik.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(uzytkownik);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UzytkownikExists(uzytkownik.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(uzytkownik);
        //}

        //// GET: Uzytkownik/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Uzytkowniks == null)
        //    {
        //        return NotFound();
        //    }

        //    var uzytkownik = await _context.Uzytkowniks
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (uzytkownik == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(uzytkownik);
        //}

        //// POST: Uzytkownik/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Uzytkowniks == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Uzytkowniks'  is null.");
        //    }
        //    var uzytkownik = await _context.Uzytkowniks.FindAsync(id);
        //    if (uzytkownik != null)
        //    {
        //        _context.Uzytkowniks.Remove(uzytkownik);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UzytkownikExists(int id)
        //{
        //  return _context.Uzytkowniks.Any(e => e.Id == id);
        //}
    }
}
