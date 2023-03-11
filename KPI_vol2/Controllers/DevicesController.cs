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

namespace KPI_vol2.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IDevice _Device;
        private readonly IDeviceType _type;

        public DevicesController(IDevice Device, IDeviceType type)
        {
            _Device = Device;
            _type = type;
        }

        // GET: Device
        public ActionResult Index()
        {
            return View(_Device.GetAllDevice());
        }

        public ViewResult Details(int id)
        {
            Device device = _Device.GetDevice(id);
            if (device == null)
            {
                Response.StatusCode = 404;
                return View("Error");
            }

            DeviceVM deviceVM = new DeviceVM()
            {
             Id = id,
             SerialNo = device.SerialNo,
             IMEI= device.IMEI,
             Model = device.Model,
             DomainName = device.DomainName,
             DeviceTypeId= device.DeviceTypeId,
            };
            return View(deviceVM);
        }

        // GET: Device/Create
        public IActionResult Create()
        {
            ViewBag.DeviceType = new SelectList(_type.DeviceTypeList(), "ID", "NazwaUrzadzenia");
            return View();
        }

        // POST: Device/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DeviceVM deviceVM)
        {
         if(ModelState.IsValid)
            {
                Device device = new Device
                {
                    Id=deviceVM.Id,
                    SerialNo=deviceVM.SerialNo,
                    IMEI=deviceVM.IMEI,
                    Model=deviceVM.Model,
                    DomainName=deviceVM.DomainName,
                    DeviceTypeId=deviceVM.DeviceTypeId,
                };
                _Device.AddDevice(device);
                return RedirectToAction("Details", new { id = device.Id });

            }
         return View();
        }

        // GET: Device/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.DeviceType = new SelectList(_type.DeviceTypeList(), "ID", "NazwaUrzadzenia");
            Device Device = _Device.GetDevice(id);

            DeviceVM deviceVM = new DeviceVM
            {
                SerialNo=Device.SerialNo,
                IMEI=Device.IMEI,
                Model=Device.Model,
                DomainName = Device.DomainName,
                DeviceTypeId = Device.DeviceTypeId,
            };
            return View(deviceVM);
        }

        // POST: Device/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DeviceVM deviceVM)
        {
            if (ModelState.IsValid)
            {
                Device device = _Device.GetDevice(deviceVM.Id);
                device.SerialNo=deviceVM.SerialNo;
                device.IMEI=deviceVM.IMEI;
                device.Model=deviceVM.Model;
                device.DomainName=deviceVM.DomainName;
                device.DeviceTypeId=deviceVM.DeviceTypeId;

                _Device.UpdateDevice(device);
                return RedirectToAction("Details", new { id = device.Id });
            }
            return View();
        }

        // GET: Device/Delete/5
        public ActionResult Delete(int id)
        {
            var Device = _Device.GetDevice(id);
            return View();
        }

        // POST: Device/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _Device.DeleteDevice(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
        }

        //private bool DeviceExists(int id)
        //{
        //  return _context.Device.Any(e => e.IdZdarzenia == id);
        //}
    }
}
