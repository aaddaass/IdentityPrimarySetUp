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
using KPI_vol2.ViewModel;
using System.Xml.Linq;
using System.Net.NetworkInformation;
using System.Globalization;

namespace KPI_vol2.Controllers
{
    public class UzytkowniksController : Controller
    {
        private readonly IUzytkownik _uzytkownik;
        private readonly ITelephone _telefon;
        private readonly IDepartaments _departaments;

        private readonly ApplicationDbContext _context;

        public UzytkowniksController(IUzytkownik uzytkownik, ITelephone telefon, IDepartaments departaments)
        {
            _uzytkownik = uzytkownik;
            _telefon = telefon;
            _departaments = departaments;
        }

        // GET: Uzytkowniks
        public ActionResult Index()
        {
            var uzytkownik = _uzytkownik.GetAll();
            return View(uzytkownik);
        }

        // GET: Uzytkowniks/Details/5
        public ViewResult Details(int id)
        {
            Uzytkownik uzytkownik = _uzytkownik.GetUzytkownik(id);
            if (uzytkownik == null)
            {
                Response.StatusCode = 404;
                return View("Error");
            }

            UzytkownikVM uzytkownikVM = new()
            {
                uzytkownik = uzytkownik

            };
            return View(uzytkownikVM);
        }

        // GET: Uzytkowniks/Create
        public IActionResult Create()
        {
            ViewBag.TelefonId = new SelectList(_telefon.TelephonNoList(), "Id", "NumerTel");
            ViewBag.Departments = new SelectList(_departaments.DepartmentsList(), "Id", "Name");
            return View();
        }

        // POST: Uzytkowniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UzytkownikEditVM uzytkownikVM)
        {
            var dataUtworzenia = DateOnly.FromDateTime(DateTime.Now);

            if (ModelState.IsValid)
            {
                Uzytkownik uzytkownik = new ()
                {
                  Id= uzytkownikVM.Id,
                  Imię= uzytkownikVM.Imię,
                  Nazwisko= uzytkownikVM.Nazwisko,
                  Email= uzytkownikVM.Email,
                  DepartmentID= uzytkownikVM.DepartmentID,
                  TelefonId= uzytkownikVM.TelefonId

                };

                _uzytkownik.AddUzytkownik(uzytkownik);

                return RedirectToAction("Details",new {id=uzytkownik.Id} );
                //return RedirectToAction("Details");
            }
            return View();
        }

        // GET: Uzytkowniks/Edit/5
        public ViewResult Edit(int id)
        {
            Uzytkownik uzytkownik = _uzytkownik.GetUzytkownik(id);
            UzytkownikEditVM uzytkownikEditVM = new ()
            {
                Id = id,
                Imię = uzytkownik.Imię,
                Nazwisko=uzytkownik.Nazwisko,
                Email=uzytkownik.Email,
                DepartmentID=uzytkownik.DepartmentID,
                TelefonId=uzytkownik.TelefonId
            };
            return View(uzytkownikEditVM);
        }

        // POST: Uzytkowniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UzytkownikEditVM uzytkownikeditVM)
        {
            if (ModelState.IsValid)
            {
                Uzytkownik Uzytkownik = _uzytkownik.GetUzytkownik(uzytkownikeditVM.Id);

                Uzytkownik.Imię = uzytkownikeditVM.Imię;
                Uzytkownik.Nazwisko = uzytkownikeditVM.Nazwisko;
                Uzytkownik.Email=uzytkownikeditVM.Email;
                Uzytkownik.DepartmentID=uzytkownikeditVM.DepartmentID;
                Uzytkownik.TelefonId= uzytkownikeditVM.TelefonId;






                _uzytkownik.UpdateUzytkownik(Uzytkownik);
                return RedirectToAction("Details");

            }
            return View();
        }

        // GET: Uzytkowniks/Delete/5
        public ActionResult Delete(int id)
        {
            var uzytkownik = _uzytkownik.GetUzytkownik(id);
            return View(uzytkownik);
        }

        // POST: Uzytkowniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _uzytkownik.DeleteUzytkownik(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //private bool UzytkownikExists(int id)
        //{
        //  return _context.Uzytkownik.Any(e => e.Id == id);
        //}
       





    }
}
