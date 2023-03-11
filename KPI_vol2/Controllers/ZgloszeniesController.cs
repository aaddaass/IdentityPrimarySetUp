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
using Microsoft.AspNetCore.Identity;

namespace KPI_vol2.Controllers
{
    public class ZgloszeniesController : Controller
    {
        private readonly IZgloszenie _zgloszenie;
        private readonly IStatus _status;
        private readonly ICategories _categories;
        private readonly IDepartaments _departaments;
        private readonly IPriorities _priorities;
        private readonly IWorkingAreas _workingAreas;
        private readonly UserManager<AppUser> _userMenager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IComments _comments;


        public ZgloszeniesController(
            IZgloszenie zgloszenie,
            IStatus status,
            ICategories categories,
            IDepartaments departaments,
            IPriorities priorities,
            IWorkingAreas workingAreas,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IComments comments
           )
        {
            _zgloszenie = zgloszenie;
            _status = status;
            _categories = categories;
            _departaments = departaments;
            _priorities = priorities;
            _workingAreas = workingAreas;
            _userMenager = userManager;
            _signInManager = signInManager;
            _comments = comments;
        }

        // GET: Zgloszenies
        public ActionResult Index()
        {
            var zgloszenia = _zgloszenie.GetAllZgloszenie();
            return View(zgloszenia);
        }

        public ActionResult KamishibayPanel()
        {
            
            return View();
        }

        public ActionResult ZgloszeniaComments()
        {
            var zgloszenia = _zgloszenie.GetAllZgloszenie();
            return View(zgloszenia);
        }

        public ActionResult ZgloszenieAllComments(int id)
        {
            var zgloszenia = _zgloszenie.GetZgloszenie(id);
            return View(zgloszenia);
        }

        public ActionResult ZgloszeniaNieprzypisane()
        {
            var zgloszenia = _zgloszenie.GetAllZgloszenie();
            return View(zgloszenia);
        }
        public ActionResult ZgloszeniaNieprzypisaneDlaMenagerów()
        {
            var usersDep = _userMenager.GetUserAsync(User).Result.DepatmentID;
            var zgloszenia = _zgloszenie.GetAllZgloszenie().Where(x => x.DepartmentId== usersDep);
            return View(zgloszenia);
        }

        // GET: Zgloszenies/Details/5
        public ViewResult Details (int id)
        {
            Zgloszenie zgloszenie = _zgloszenie.GetZgloszenie(id);
            if(zgloszenie ==null)
            {
                Response.StatusCode = 404;
            }
            ZgloszeniaDetails zgloszenieVM = new ZgloszeniaDetails()
            {
                zgloszenie = zgloszenie,
            };
            return View(zgloszenieVM);

            
        }
        public ViewResult DetailsWithComments(int id)
        {
            Zgloszenie zgloszenie = _zgloszenie.GetZgloszenie(id);
           // Comments comments=_comments.GetComments(zgloszenie.Id);
                if (zgloszenie == null)
            {
                Response.StatusCode = 404;
            }
            Zglo_Comments zgloszenieVM = new Zglo_Comments()
            {
                Zgloszenie = zgloszenie,
               // Comments = zgloszenieVM.Comments
            };
            return View(zgloszenieVM);


        }

        // GET: Zgloszenies/Create
        public IActionResult Create()
        {
            ViewBag.AssignetTo      = new SelectList(_userMenager.Users,                "Id", "FullName");
            ViewBag.Category        = new SelectList(_categories.CategoriesList(),      "Id",       "Name");
            ViewBag.Department      = new SelectList(_departaments.DepartmentsList(),   "Id",       "Name");
            ViewBag.Priority        = new SelectList(_priorities.PrioritiesList(),      "Id",       "Name");
            ViewBag.WorkingArea     = new SelectList(_workingAreas.WorkingAreasList(),  "Id",       "Name");
            ViewBag.StatusByPoster  = new SelectList(_status.StatusList(),              "IdStatus", "NameStatus");
            ViewBag.StatusByAssigned= new SelectList(_status.StatusList(),              "IdStatus", "NameStatus");
            
            return View();
        }

        // POST: Zgloszenies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ZgloszenieVM zgloszenieVM)
        {
            if (ModelState.IsValid)
            {
                var uzytkownikId = _userMenager.GetUserId(User);

                Zgloszenie zgloszenie = new Zgloszenie
                {
                    Id = zgloszenieVM.Id,
                    PostDate = DateTime.Now,
                    UserID = uzytkownikId,
                    CategoryId = zgloszenieVM.CategoryId,
                    Topic = zgloszenieVM.Topic,
                    DepartmentId = zgloszenieVM.DepartmentId,
                    AssignedToId = zgloszenieVM.AssignedToId,
                    PriorityId = zgloszenieVM.PriorityId,
                    Deadline = zgloszenieVM.Deadline,
                    ClosedOn = zgloszenieVM.ClosedOn,
                    WorkingAreaId = zgloszenieVM.WorkingAreaId,
                    StatusByAssigned_Id = zgloszenieVM.StatusByAssigned_Id,
                    StatusByPoster_Id = zgloszenieVM.StatusByPoster_Id,


                };
                _zgloszenie.AddZgloszenie(zgloszenie);
                return RedirectToAction("Details", new {id=zgloszenie.Id});
            }
            return View();
        }

        // GET: Zgloszenies/Edit/5
        public ViewResult Edit(int id)
        {
            ViewBag.User = new SelectList(_userMenager.Users, "Id", "Email");
            ViewBag.AssignetTo = new SelectList(_userMenager.Users, "Id", "Email");
            ViewBag.Category = new SelectList(_categories.CategoriesList(), "Id", "Name");
            ViewBag.Department = new SelectList(_departaments.DepartmentsList(), "Id", "Name");
            ViewBag.Priority = new SelectList(_priorities.PrioritiesList(), "Id", "Name");
            ViewBag.WorkingArea = new SelectList(_workingAreas.WorkingAreasList(), "Id", "Name");
            ViewBag.StatusByPoster = new SelectList(_status.StatusList(), "IdStatus", "NameStatus");
            ViewBag.StatusByAssigned = new SelectList(_status.StatusList(), "IdStatus", "NameStatus");

            Zgloszenie zgloszenie=_zgloszenie.GetZgloszenie(id);
            ZgloszenieVM zgloszenieVM = new ZgloszenieVM
            {
                Id                  = id,
                PostDate            = zgloszenie.PostDate,
                UserID              = zgloszenie.UserID,
                CategoryId          =zgloszenie.CategoryId,
                Topic               =zgloszenie.Topic,
                DepartmentId        =zgloszenie.DepartmentId,
                AssignedToId        =zgloszenie.AssignedToId,
                PriorityId          =zgloszenie.PriorityId,
                Deadline            =zgloszenie.Deadline,
                ClosedOn            =zgloszenie.ClosedOn,
                WorkingAreaId       =zgloszenie.WorkingAreaId,
                StatusByAssigned_Id =zgloszenie.StatusByAssigned_Id,
                StatusByPoster_Id   =zgloszenie.StatusByPoster_Id,
            };
            return View(zgloszenieVM);
        }

        // POST: Zgloszenies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ZgloszenieVM zgloszenieVM)
        {
            

            if (ModelState.IsValid)
            {
                Zgloszenie zgloszenie = _zgloszenie.GetZgloszenie(zgloszenieVM.Id);
                
                zgloszenie.AssignedToId         = zgloszenieVM.AssignedToId;
                zgloszenie.Topic                = zgloszenieVM.Topic;
                zgloszenie.PriorityId           = zgloszenieVM.PriorityId;
                zgloszenie.UserID               = zgloszenieVM.UserID;
                zgloszenie.CategoryId           = zgloszenieVM.CategoryId;
                zgloszenie.DepartmentId         = zgloszenieVM.DepartmentId;
                zgloszenie.Deadline             = zgloszenieVM.Deadline;
                zgloszenie.ClosedOn             = zgloszenieVM.ClosedOn;
                zgloszenie.WorkingAreaId        = zgloszenieVM.WorkingAreaId;
                zgloszenie.StatusByAssigned_Id  = zgloszenieVM.StatusByAssigned_Id;
                zgloszenie.StatusByPoster_Id    = zgloszenieVM.StatusByPoster_Id;
                zgloszenie.PostDate             = zgloszenieVM.PostDate;

                _zgloszenie.UpdateZgloszenie(zgloszenie);
               
                
                return RedirectToAction(nameof(Index));
            }
            return View();
            
        }

        //// GET: Zgloszenies/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Zgloszenies == null)
        //    {
        //        return NotFound();
        //    }

        //    var zgloszenie = await _context.Zgloszenies
        //        .Include(z => z.AssignedTo)
        //        .Include(z => z.Category)
        //        .Include(z => z.Department)
        //        .Include(z => z.PostedBy)
        //        .Include(z => z.Priority)
        //        .Include(z => z.Status)
        //        .Include(z => z.StatusByAssigned)
        //        .Include(z => z.WorkingArea)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (zgloszenie == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(zgloszenie);
        //}

        //// POST: Zgloszenies/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Zgloszenies == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Zgloszenies'  is null.");
        //    }
        //    var zgloszenie = await _context.Zgloszenies.FindAsync(id);
        //    if (zgloszenie != null)
        //    {
        //        _context.Zgloszenies.Remove(zgloszenie);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        // GET: Zdarzenias/Delete/5
        public ActionResult Delete(int id)
        {
            var zgloszenie = _zgloszenie.GetZgloszenie(id);

            Zgloszenie zgloszenieVM = new Zgloszenie
            {
                Id = id,
                PostDate = zgloszenie.PostDate,
                UserID = zgloszenie.UserID,
                CategoryId = zgloszenie.CategoryId,
                Topic = zgloszenie.Topic,
                DepartmentId = zgloszenie.DepartmentId,
                AssignedToId = zgloszenie.AssignedToId,
                PriorityId = zgloszenie.PriorityId,
                Deadline = zgloszenie.Deadline,
                ClosedOn = zgloszenie.ClosedOn,
                WorkingAreaId = zgloszenie.WorkingAreaId,
                StatusByAssigned_Id = zgloszenie.StatusByAssigned_Id,
                StatusByPoster_Id = zgloszenie.StatusByPoster_Id,
            };
            return View(zgloszenie);
        }

        // POST: Zdarzenias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _zgloszenie.DeleteZgloszenie(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //private bool ZgloszenieExists(int id)
        //{
        //  return _context.Zgloszenies.Any(e => e.Id == id);
        //}
    }
}
