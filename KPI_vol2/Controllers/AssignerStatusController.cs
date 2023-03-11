//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using KPI_vol2.Data;
//using KPI_vol2.Models;
//using KPI_vol2.Interface;

//namespace KPI_vol2.Controllers
//{
//    public class AssignerStatusController : Controller
//    {
//        private readonly IAssignerStatus _AssignerStatus;

//        public AssignerStatusController(IAssignerStatus AssignerStatus)
//        {
//            _AssignerStatus = AssignerStatus;
//        }

//        // GET: AssignerStatus
//        public ActionResult Index()
//        {
//            return View(_AssignerStatus.GetAllAssignerStatus());
//        }



//        // GET: AssignerStatus/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: AssignerStatus/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(AssignerStatus AssignerStatus)
//        {
//            if (ModelState.IsValid)
//            {
//                AssignerStatus newAssignerStatus = new AssignerStatus
//                {
//                    Name = AssignerStatus.Name
//                };
//                _AssignerStatus.AddAssignerStatus(AssignerStatus);
//                return RedirectToAction("Index");
//            }
//            return View();
//        }

//        // GET: AssignerStatus/Edit/5
//        public ActionResult Edit(int id)
//        {
//            AssignerStatus AssignerStatus = _AssignerStatus.GetAssignerStatus(id);
//            return View(AssignerStatus);
//        }

//        // POST: AssignerStatus/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(AssignerStatus AssignerStatus)
//        {
//            if (ModelState.IsValid)
//            {
//                _AssignerStatus.UpdateAssignerStatus(AssignerStatus);
//                return RedirectToAction("Index");
//            }
//            return View();
//        }

//        // GET: AssignerStatus/Delete/5
//        public ActionResult Delete(int id)
//        {
//            var AssignerStatus = _AssignerStatus.GetAssignerStatus(id);
//            return View();
//        }

//        // POST: AssignerStatus/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            try
//            {
//                _AssignerStatus.DeleteAssignerStatus(id);
//                return RedirectToAction("Index");
//            }
//            catch (Exception)
//            {

//                return View();
//            }
//        }

//        //private bool AssignerStatusExists(int id)
//        //{
//        //  return _context.AssignerStatus.Any(e => e.IdZdarzenia == id);
//        //}
//    }
//}
