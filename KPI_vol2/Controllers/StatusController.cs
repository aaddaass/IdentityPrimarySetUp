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
using System.Data;
using KPI_vol2.ViewModel;

namespace KPI_vol2.Controllers
{
    public class StatusController : Controller
    {
        private readonly IStatus _status;

        public StatusController(IStatus status)
        {
            _status=status;
        }

        // GET: Status
        public ViewResult Index()
        {
              return View(_status.GetAll());
        }

        // GET: Status/Details/5
        //public async Task<IActionResult> Details(int id)
        //{
        //    Status status = _status.GetStatus(id); 
        //    if(status == null)
        //    {
        //        Response.StatusCode = 404;
        //        return View("UserNotFound",id);
        //    }

        //    Status statusVM = new Status()
        //    {
        //        Name= status.Name,
        //    };
        //    return View(statusVM);
        //}

        // GET: Status/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( StatusVM status)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Status newstatus = new Status
            {
                Name = status.Name,
            };
            _status.AddStatus(newstatus);
            return RedirectToAction("Index");
        }

        // GET: Status/Edit/5
        public ActionResult Edit(int id)
        {
           Status status=_status.GetStatus(id);
            StatusVM statusEdit = new StatusVM
            {
                IdStatus=status.IdStatus,
                Name = status.Name,
            };
            return View(statusEdit);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StatusVM statusVM)
        {
          if(ModelState.IsValid)
            {
                Status status=_status.GetStatus(statusVM.IdStatus);
                status.Name = statusVM.Name;

                _status.UpdateStatus(status);
                return RedirectToAction("Index");
            }
            return View();
          
        }

        // GET: Status/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
          
            var status = _status.GetStatus(id);
            return View(status);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                Status status = _status.GetStatus(id);
               _status.DeleteStatus(id);
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

       
    }
}
