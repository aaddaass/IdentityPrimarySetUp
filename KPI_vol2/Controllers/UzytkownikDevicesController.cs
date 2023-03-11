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
    public class UzytkownikDevicesController : Controller
    {
        private readonly IUrzyt_Device _urzyt_Device;
        private readonly IUzytkownik _uzytkownik;
        private readonly IDevice _device;

        public UzytkownikDevicesController(IUrzyt_Device urzyt_Device,IUzytkownik uzytkownik,IDevice device)
        {
            _urzyt_Device=urzyt_Device;
            _uzytkownik=uzytkownik;
            _device=device;
        }

        // GET: UzytkownikDevices
        public ActionResult Index()
        {
           // var uzytdev = _urzyt_Device.GetAllUzytkownikDevice();
            var uzytdev = _uzytkownik.GetAll();
            return View(uzytdev);
        }

        // GET: UzytkownikDevices/Details/5
        public ViewResult Details(int id)//id składa się z dwóch kluczy obcych
                                         //rozważyć albo dodanie nowego pola id
                                         //lub dowiedzieć sie jak zidentyfikować wpis
                                         //po dwóch kluczach id 
                                         //lub skonstruwać model widoku pobierający 
                                         // dane użytkownika z przypisanymiu mu urządzeniami
                                         //chyba najlepsze wyjście
        {
            UzytkownikDevice uzytkownik = _urzyt_Device.GetUzytkownikDevice(id);
            if (uzytkownik == null)
            {
                Response.StatusCode = 404;
                return View("Error");
            }

            UzytkownikDeviceVM uzytkownikDeviceVM = new UzytkownikDeviceVM()
            {
                UzytkownikDevice = uzytkownik,
            };
            return View(uzytkownikDeviceVM);
        }

        // GET: UzytkownikDevices/Create
        public IActionResult Create()
        {
            ViewBag.uzytkownik = new SelectList(_uzytkownik.uzytkownikList(), "Id", "FullName");//dodać dodatkowe pole w modelu uzytkownika łączące imie i nazwisko
            ViewBag.device= new SelectList(_device.DeviceList(), "Id", "Model");
            return View();
        }

        // POST: UzytkownikDevices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UzyDevVM uzyDevVM)
        {
            if (ModelState.IsValid)
            {
                UzytkownikDevice uzytkownikDevice = new()
                {
                    DeviceID = uzyDevVM.DeviceID,
                    UzytkownikID=uzyDevVM.UzytkownikID
                };
               _urzyt_Device.AddUzytkownikDevice(uzytkownikDevice);
                return RedirectToAction("Details", new {id=uzyDevVM.UzytkownikID});
            }
                return RedirectToAction(nameof(Index));
            
        }

        //        // GET: UzytkownikDevices/Edit/5
        //        public async Task<IActionResult> Edit(int? id)
        //        {
        //            if (id == null || _context.UzytkownikDevices == null)
        //            {
        //                return NotFound();
        //            }

        //            var uzytkownikDevice = await _context.UzytkownikDevices.FindAsync(id);
        //            if (uzytkownikDevice == null)
        //            {
        //                return NotFound();
        //            }
        //            ViewData["DeviceID"] = new SelectList(_context.Devices, "Id", "Id", uzytkownikDevice.DeviceID);
        //            ViewData["UzytkownikID"] = new SelectList(_context.Uzytkowniks, "Id", "Id", uzytkownikDevice.UzytkownikID);
        //            return View(uzytkownikDevice);
        //        }

        //        // POST: UzytkownikDevices/Edit/5
        //        // To protect from overposting attacks, enable the specific properties you want to bind to.
        //        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> Edit(int id, [Bind("UzytkownikID,DeviceID")] UzytkownikDevice uzytkownikDevice)
        //        {
        //            if (id != uzytkownikDevice.DeviceID)
        //            {
        //                return NotFound();
        //            }

        //            if (ModelState.IsValid)
        //            {
        //                try
        //                {
        //                    _context.Update(uzytkownikDevice);
        //                    await _context.SaveChangesAsync();
        //                }
        //                catch (DbUpdateConcurrencyException)
        //                {
        //                    if (!UzytkownikDeviceExists(uzytkownikDevice.DeviceID))
        //                    {
        //                        return NotFound();
        //                    }
        //                    else
        //                    {
        //                        throw;
        //                    }
        //                }
        //                return RedirectToAction(nameof(Index));
        //            }
        //            ViewData["DeviceID"] = new SelectList(_context.Devices, "Id", "Id", uzytkownikDevice.DeviceID);
        //            ViewData["UzytkownikID"] = new SelectList(_context.Uzytkowniks, "Id", "Id", uzytkownikDevice.UzytkownikID);
        //            return View(uzytkownikDevice);
        //        }

        //        // GET: UzytkownikDevices/Delete/5
        //        public async Task<IActionResult> Delete(int? id)
        //        {
        //            if (id == null || _context.UzytkownikDevices == null)
        //            {
        //                return NotFound();
        //            }

        //            var uzytkownikDevice = await _context.UzytkownikDevices
        //                .Include(u => u.Device)
        //                .Include(u => u.Uzytkownik)
        //                .FirstOrDefaultAsync(m => m.DeviceID == id);
        //            if (uzytkownikDevice == null)
        //            {
        //                return NotFound();
        //            }

        //            return View(uzytkownikDevice);
        //        }

        //        // POST: UzytkownikDevices/Delete/5
        //        [HttpPost, ActionName("Delete")]
        //        [ValidateAntiForgeryToken]
        //        public async Task<IActionResult> DeleteConfirmed(int id)
        //        {
        //            if (_context.UzytkownikDevices == null)
        //            {
        //                return Problem("Entity set 'ApplicationDbContext.UzytkownikDevices'  is null.");
        //            }
        //            var uzytkownikDevice = await _context.UzytkownikDevices.FindAsync(id);
        //            if (uzytkownikDevice != null)
        //            {
        //                _context.UzytkownikDevices.Remove(uzytkownikDevice);
        //            }

        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }

        //        private bool UzytkownikDeviceExists(int id)
        //        {
        //          return _context.UzytkownikDevices.Any(e => e.DeviceID == id);
        //        }
    }
}
