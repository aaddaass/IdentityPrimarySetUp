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

namespace KPI_vol2.Controllers
{
    public class ZdarzeniasController : Controller
    {
        private readonly IZdarzenia _zdarzenia;

        public ZdarzeniasController(IZdarzenia zdarzenia)
        {
            _zdarzenia=zdarzenia;
        }

        // GET: Zdarzenias
        public ActionResult Index()
        {
            var zdarzenia = _zdarzenia.GetAllZdarzenia();
              return View(zdarzenia);
        }

        // GET: Zdarzenias/Details/5
        public ViewResult Details(int id)
        {
            Zdarzenia zdarzenia = _zdarzenia.GetZdarzenia(id);
            if (id == null)
            {
                Response.StatusCode = 404;
                return View("Error");
            }

            ZdarzenieVM zdarzenieVM = new ZdarzenieVM()
            {
                Id = id,
                Name                = zdarzenia.Name,
                Opis                = zdarzenia.Opis,
                Naprawa             = zdarzenia.Naprawa,
                DataZdarzenia       = zdarzenia.DataZdarzenia,
                DataWykonania       = zdarzenia.DataWykonania,
                OsobaOdpowiedzialna = zdarzenia.OsobaOdpowiedzialna,
            };
                return View(zdarzenieVM);
        }

        // GET: Zdarzenias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zdarzenias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ZdarzenieVM zdarzeniaVM)
        {
            if (ModelState.IsValid)
            {
                Zdarzenia zdarzenie = new Zdarzenia
                {
                    Id=zdarzeniaVM.Id,
                    Name= zdarzeniaVM.Name,
                    Opis= zdarzeniaVM.Opis,
                    Naprawa= zdarzeniaVM.Naprawa,
                    DataZdarzenia=DateTime.Now,
                    DataWykonania= zdarzeniaVM.DataWykonania,
                    OsobaOdpowiedzialna=zdarzeniaVM.OsobaOdpowiedzialna,
                };

                _zdarzenia.AddZdarzenia(zdarzenie);
                
                return RedirectToAction("Details",new {id=zdarzenie.Id} );
            }
            return View();
        }

        // GET: Zdarzenias/Edit/5
        public ViewResult Edit(int id)
        {
            Zdarzenia zdarzenia=_zdarzenia.GetZdarzenia(id);
            ZdarzeniaEditVM zdarzenieEditVM = new ZdarzeniaEditVM
            {
                Id                  = id,
                Name                = zdarzenia.Name,
                Opis                = zdarzenia.Opis,
                Naprawa             = zdarzenia.Naprawa,
                DataWykonania       = zdarzenia.DataWykonania,
                DataZdarzenia       = zdarzenia.DataZdarzenia,
                OsobaOdpowiedzialna = zdarzenia.OsobaOdpowiedzialna
            };
            return View(zdarzenieEditVM);
        }

        // POST: Zdarzenias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( ZdarzeniaEditVM zdarzeniaeditVM)
        {
            if(ModelState.IsValid)
            {
                Zdarzenia zdarzenia = _zdarzenia.GetZdarzenia(zdarzeniaeditVM.Id);

                zdarzenia.Name                  = zdarzeniaeditVM.Name;
                zdarzenia.Opis                  = zdarzeniaeditVM.Opis;
                zdarzenia.Naprawa               = zdarzeniaeditVM.Naprawa;
                zdarzenia.DataWykonania         = zdarzeniaeditVM.DataWykonania;
                zdarzenia.DataZdarzenia         = zdarzeniaeditVM.DataZdarzenia;
                zdarzenia.OsobaOdpowiedzialna = zdarzeniaeditVM.OsobaOdpowiedzialna;

                _zdarzenia.UpdateZdarzenia(zdarzenia);
                return RedirectToAction("Index");

            }
            return View();
        }

        // GET: Zdarzenias/Delete/5
        public ActionResult Delete(int id)
        {
            var zgloszenie = _zdarzenia.GetZdarzenia(id);
            return View(zgloszenie);
        }

        // POST: Zdarzenias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _zdarzenia.DeleteZdarzenia(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //private bool ZdarzeniaExists(int id)
        //{
        //  return _context.Zdarzenia.Any(e => e.Id == id);
        //}
    }
}
