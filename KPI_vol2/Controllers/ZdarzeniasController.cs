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
    public class ZdarzeniasController : Controller
    {
        private readonly IZdarzenia _zdarzenia;
        private readonly IStatus _status;

        private readonly ApplicationDbContext _context;

        public ZdarzeniasController(IZdarzenia zdarzenia, IStatus status, ApplicationDbContext context)
        {
            _zdarzenia = zdarzenia;
            _status = status;
            _context = context;
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
            if (zdarzenia == null)
            {
                Response.StatusCode = 404;
                return View("Error");
            }

            ZdarzenieDetailsVM zdarzenieVM = new ZdarzenieDetailsVM()
            {
                Zdarzenia = zdarzenia,
                //Id                  = id,
                //Name                = zdarzenia.Name,
                //Opis                = zdarzenia.Opis,
                //Naprawa             = zdarzenia.Naprawa,
                //DataZdarzenia       = zdarzenia.DataZdarzenia,
                //DataWykonania       = zdarzenia.DataWykonania,
                //OsobaOdpowiedzialna = zdarzenia.OsobaOdpowiedzialna,
                //IdStatus            =zdarzenia.CurentStatusId,
            };
                return View(zdarzenieVM);
        }

        // GET: Zdarzenias/Create
        public IActionResult Create()
        {
            ViewBag.Status = new SelectList(_status.StatusList(), "IdStatus", "NameStatus");
            return View();
        }

        // POST: Zdarzenias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ZdarzenieVM zdarzeniaVM)
        {
            var dataUtworzenia = DateOnly.FromDateTime(DateTime.Now);

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
                    CurentStatusId=zdarzeniaVM.IdStatus
                   
                };

                _zdarzenia.AddZdarzenia(zdarzenie);
                
                //return RedirectToAction("Details",new {id=zdarzenie.Id} );
                return RedirectToAction("Calendar");
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
        public ActionResult GetEvents()
        {

           
            if(_context.Zdarzenia.Any(t=>t.Name==null))
                {
                return Json(

                 //zdarzenia.Select(
                 _context.Zdarzenia.Select(

                      e => new
                      {


                          //id = e.Id,
                          //title = e.Name,

                          start = e.DataZdarzenia.ToString("yyyy-MM-dd"),
                          //end = e.DataZdarzenia.ToString("yyyy-MM-dd"),
                          setAllDay = true,
                          backgroundColor = "red",
                      }).ToList());
            }
            else
            {
                return Json(

                 //zdarzenia.Select(
                 _context.Zdarzenia.Select(

                      e => new
                      {


                          //id = e.Id,
                          //title = e.Name,

                          start = e.DataZdarzenia.ToString("yyyy-MM-dd"),
                          //end = e.DataZdarzenia.ToString("yyyy-MM-dd"),
                          setAllDay = true,
                          backgroundColor = "green",
                      }).ToList());
            }

           
            
           
        }

        public ActionResult Calendar()
        {
            var zdarzenia = _zdarzenia.GetAllZdarzenia();

            var year=DateTime.Now.Year;
            var month = DateTime.Now.Month;
            var day = DateTime.Now.Day;

            var currentCulture = CultureInfo.CurrentCulture;
            var weekNo = currentCulture.Calendar.GetWeekOfYear(
                            new DateTime(year,month,day),
                            currentCulture.DateTimeFormat.CalendarWeekRule,
                            currentCulture.DateTimeFormat.FirstDayOfWeek);


            var week=DateTime.Now.DayOfYear;

            var numweek = week / 6;
            ViewBag.act_week =weekNo ;
            ViewBag.I_next_week=weekNo+1 ;
            ViewBag.II_next_week=weekNo+2 ;
            ViewBag.III_next_week=weekNo+3 ;
            ViewBag.IV_next_week=weekNo+4 ;

            return View(zdarzenia);
        }

      


       
    }
}
