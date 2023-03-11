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
    public class TelephonNoesController : Controller
    {
        private readonly ITelephone _TelephonNo;

        public TelephonNoesController(ITelephone TelephonNo)
        {
            _TelephonNo = TelephonNo;
        }

        // GET: TelephonNo
        public ActionResult Index()
        {
            return View(_TelephonNo.GetAllTelephonNo());
        }



        // GET: TelephonNo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TelephonNo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TelephonNo TelephonNo)
        {
            if (ModelState.IsValid)
            {
                TelephonNo newTelephonNo = new TelephonNo
                {
                    NumerTel= TelephonNo.NumerTel
                };
                _TelephonNo.AddTelephonNo(TelephonNo);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: TelephonNo/Edit/5
        public ActionResult Edit(int id)
        {
            TelephonNo TelephonNo = _TelephonNo.GetTelephonNo(id);
            return View(TelephonNo);
        }

        // POST: TelephonNo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TelephonNo TelephonNo)
        {
            if (ModelState.IsValid)
            {
                _TelephonNo.UpdateTelephonNo(TelephonNo);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: TelephonNo/Delete/5
        public ActionResult Delete(int id)
        {
            var TelephonNo = _TelephonNo.GetTelephonNo(id);
            return View();
        }

        // POST: TelephonNo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _TelephonNo.DeleteTelephonNo(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }

        //private bool TelephonNoExists(int id)
        //{
        //  return _context.TelephonNo.Any(e => e.IdZdarzenia == id);
        //}
    }
}
