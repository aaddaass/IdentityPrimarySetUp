using Microsoft.AspNetCore.Mvc;

namespace KPI_vol2.Controllers
{
    public class BhpController : Controller
    {
        public IActionResult Index()
        {
            int year=DateTime.Now.Year;
            int month=DateTime.Now.Month;
            int days = DateTime.DaysInMonth(year, month);
            int[] daysOfMonth=new int[days];
            int lengthOfTable=daysOfMonth.Length;

            ViewBag.array=days;

            return View();
        }
    }
}
