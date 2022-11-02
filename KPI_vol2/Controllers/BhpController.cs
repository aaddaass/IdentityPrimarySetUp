using Microsoft.AspNetCore.Mvc;

namespace KPI_vol2.Controllers
{
    public class BhpController : Controller
    {
        public IActionResult Index()
        {
            DateTime dateTime = DateTime.Now;
            var dnimiesiaca=DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
            ViewBag.dni=dnimiesiaca;
            ViewBag.miesiac = DateTime.Now.ToString("MMMM");

            return View();
        }
    }
}
