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
    public class DeviceTypesController : Controller
    {
        private readonly IDeviceType _DeviceType;

        public DeviceTypesController(IDeviceType DeviceType)
        {
            _DeviceType = DeviceType;
        }

        // GET: DeviceType
        public ActionResult Index()
        {
            return View(_DeviceType.GetAllDeviceType());
        }



        // GET: DeviceType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeviceType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DeviceType DeviceType)
        {
            if (ModelState.IsValid)
            {
                DeviceType newDeviceType = new DeviceType
                {
                    NazwaUrzadzenia = DeviceType.NazwaUrzadzenia
                };
                _DeviceType.AddDeviceType(DeviceType);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: DeviceType/Edit/5
        public ActionResult Edit(int id)
        {
            DeviceType DeviceType = _DeviceType.GetDeviceType(id);
            return View(DeviceType);
        }

        // POST: DeviceType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DeviceType DeviceType)
        {
            if (ModelState.IsValid)
            {
                _DeviceType.UpdateDeviceType(DeviceType);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: DeviceType/Delete/5
        public ActionResult Delete(int id)
        {
            var DeviceType = _DeviceType.GetDeviceType(id);
            return View();
        }

        // POST: DeviceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _DeviceType.DeleteDeviceType(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }

        //private bool DeviceTypeExists(int id)
        //{
        //  return _context.DeviceType.Any(e => e.IdZdarzenia == id);
        //}
    }
}
