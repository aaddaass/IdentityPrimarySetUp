//using KPI_vol2.Data;
//using KPI_vol2.Interface;
//using KPI_vol2.Models;
//using KPI_vol2.ViewModel;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;

//namespace KPI_vol2.Controllers
//{
//    public class BhpController : Controller
//    {
//        private readonly IZdarzenia _zdarzenia;
//        private readonly IStatus _status;

//        private readonly ApplicationDbContext _context;

//        public BhpController(IZdarzenia zdarzenia, IStatus status, ApplicationDbContext context)
//        {
//            _zdarzenia = zdarzenia;
//            _status = status;
//            _context = context;
//        }


//        // GET: Zdarzenias/Create
//        public IActionResult Create()
//        {
//            ViewBag.Status = new SelectList(_status.StatusList(), "IdStatus", "NameStatus");
//            return View();
//        }

//        // POST: Zdarzenias/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(ZdarzenieVM zdarzeniaVM)
//        {
//            var dataUtworzenia = DateOnly.FromDateTime(DateTime.Now);

//            if (ModelState.IsValid)
//            {
//                Zdarzenia zdarzenie = new Zdarzenia
//                {
//                    Id = zdarzeniaVM.Id,
//                    Name = zdarzeniaVM.Name,
//                    Opis = zdarzeniaVM.Opis,
//                    Naprawa = zdarzeniaVM.Naprawa,
//                    DataZdarzenia = DateTime.Now,
//                    DataWykonania = zdarzeniaVM.DataWykonania,
//                    OsobaOdpowiedzialna = zdarzeniaVM.OsobaOdpowiedzialna,
//                    CurentStatusId = zdarzeniaVM.IdStatus

//                };

//                _zdarzenia.AddZdarzenia(zdarzenie);

//                //return RedirectToAction("Details",new {id=zdarzenie.Id} );
//                return RedirectToAction("Index");
//            }
//            return View();
//        }

//        [HttpPost]
//        public JsonResult SaveZdarzenie(Zdarzenia z)
//        {
//            ViewBag.Status = new SelectList(_status.StatusList(), "IdStatus", "NameStatus");

//            var status = false;
//            if(z.Id>0)
//            {
//                var v=_context.Zdarzenia.Where(x => x.Id == z.Id).FirstOrDefault();
//                if(v!=null)
//                {
//                    v.Name=z.Name;
//                    v.Opis=z.Opis;
//                    v.Naprawa=z.Naprawa;
//                    v.DataZdarzenia=z.DataZdarzenia;
//                    v.DataWykonania = z.DataWykonania;
//                    v.OsobaOdpowiedzialna=z.OsobaOdpowiedzialna;
//                    v.Status = z.Status;
//                }
//                else
//                {
//                    _context.Add(z);
//                }
//                _context.SaveChanges();
//                status = true;
//                return Json(status);
//            }
//        }
//    }
//}
