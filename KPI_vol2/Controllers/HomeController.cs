using KPI_vol2.Data;
using KPI_vol2.Interface;
using KPI_vol2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace KPI_vol2.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IZdarzenia _zdarzenia;
        private readonly IStatus _status;

        private readonly ApplicationDbContext _context;

        public HomeController(IZdarzenia zdarzenia, IStatus status, ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _zdarzenia = zdarzenia;
            _status = status;
            _context = context;
            _logger = logger;
        }

     

        public IActionResult Index()
        {
            //var dzien = _zdarzenia.PierwszeZdarzenie;

            var MinDate = (from d in _context.Zdarzenia select d.DataZdarzenia).Min();
            var actDay=DateTime.Now.Date;
            ViewBag.dzien = MinDate;
            ViewBag.actdzien = actDay;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            
        {
            return View();
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult DictionaryTables() // kontroler odnoszący się do widoku tabel słownikowych z opisem
        {
            return View();  
        }
    }
}