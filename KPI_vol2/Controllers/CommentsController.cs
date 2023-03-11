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
using Microsoft.AspNetCore.Identity;
using KPI_vol2.ViewModel;

namespace KPI_vol2.Controllers
{
    public class CommentsController : Controller
    {
        private readonly IZgloszenie            _zgloszenie;
        private readonly IComments              _comments;
        private readonly UserManager<AppUser>   _userMenager;       
        private readonly IStatus                _status;
        private readonly ICategories            _categories;
        private readonly IDepartaments          _departaments;
        private readonly IPriorities            _priorities;
        private readonly IWorkingAreas          _workingAreas;
        private readonly ApplicationDbContext _db;


        public CommentsController(
            IZgloszenie zgloszenie,
            IComments comments,
            UserManager<AppUser> userMenager,
            IStatus status,
            ICategories categories,
            IDepartaments departaments,
            IPriorities priorities,
            IWorkingAreas workingAreas,
            ApplicationDbContext db
            )
          
        {
            _comments       = comments;
            _zgloszenie     = zgloszenie;
            _userMenager    = userMenager;          
            _status         = status;
            _categories     = categories;
            _departaments   = departaments;
            _priorities     = priorities;
            _workingAreas   = workingAreas;
            _db = db;
           
        }

        // GET: Comments
        public ActionResult Index()
        {
            var com = _comments.GetAllComments();
            return View(com);
        }

        // GET: Comments/Details/5
        public ViewResult Details(int id)
        {
            Comments comments = _comments.GetComments(id);
            if(comments == null)
            {
                Response.StatusCode = 404;
            }
            CommentsDetails commentsDetails = new CommentsDetails()
            {
                CommentsVModel = comments,
            };
            return View(commentsDetails);
           
        }

        // GET: Comments/Create
        public IActionResult Create()//pierwszy komentarz = utworzenie zgłoszenia kamishibay
        {
            ViewBag.AssignetTo = new SelectList(_userMenager.Users, "Id", "FullName");
            ViewBag.Category = new SelectList(_categories.CategoriesList(), "Id", "Name");
            ViewBag.Department = new SelectList(_departaments.DepartmentsList(), "Id", "Name");
            ViewBag.Priority = new SelectList(_priorities.PrioritiesList(), "Id", "Name");
            ViewBag.WorkingArea = new SelectList(_workingAreas.WorkingAreasList(), "Id", "Name");
            ViewBag.StatusByPoster = new SelectList(_status.StatusList(), "IdStatus", "NameStatus");
            ViewBag.StatusByAssigned = new SelectList(_status.StatusList(), "IdStatus", "NameStatus");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FirstCommentVM firstCommentVM)
        {
            if(ModelState.IsValid)
            {
                var uzytkownikId = _userMenager.GetUserId(User);

                Zgloszenie zgloszenie = new Zgloszenie
                {
                    Id = firstCommentVM.Id,
                    PostDate = DateTime.Now,
                    UserID = uzytkownikId,
                    CategoryId = firstCommentVM.CategoryId,
                    Topic = firstCommentVM.Topic,
                    DepartmentId = firstCommentVM.DepartmentId,
                    AssignedToId = firstCommentVM.AssignedToId,
                    PriorityId = firstCommentVM.PriorityId,
                    Deadline = firstCommentVM.Deadline,
                    ClosedOn = firstCommentVM.ClosedOn,
                    WorkingAreaId = firstCommentVM.WorkingAreaId,
                    StatusByAssigned_Id = firstCommentVM.StatusByAssigned_Id,
                    StatusByPoster_Id = firstCommentVM.StatusByPoster_Id,
                };
                _zgloszenie.AddZgloszenie(zgloszenie);
                int zglo=zgloszenie.Id;
                Comments comments = new Comments
                {
                    AttachedToTaskId = zglo,
                    CommentedById = uzytkownikId,
                    CommentedOn = DateTime.Now,
                    Comment = firstCommentVM.Comment
                };
                _comments.AddComments(comments);

                //return RedirectToAction("Details", new { id = zgloszenie.Id });
                return RedirectToAction("Index");


            }
            return View();
            
        }

        // GET: Comments/Create
        public IActionResult CreateBHP()//pierwszy komentarz = utworzenie zgłoszenia kamishibay
        {
            ViewBag.AssignetTo = new SelectList(_userMenager.Users, "Id", "FullName");
            ViewBag.Category = new SelectList(_categories.CategoriesList(), "Id", "Name");
            //ViewBag.Department = new SelectList(_departaments.DepartmentsList(), "Id", "Name");
            ViewBag.Priority = new SelectList(_priorities.PrioritiesList(), "Id", "Name");
            ViewBag.WorkingArea = new SelectList(_workingAreas.WorkingAreasList(), "Id", "Name");
            ViewBag.StatusByPoster = new SelectList(_status.StatusList(), "IdStatus", "NameStatus");
            ViewBag.StatusByAssigned = new SelectList(_status.StatusList(), "IdStatus", "NameStatus");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBHP(FirstCommentVM firstCommentVM)
        {
            if (ModelState.IsValid)
            {
                
                    var BHPid = _db.Departments.Where(z => z.Name == "BHP").Select(z => z.Id);

                var uzytkownikId = _userMenager.GetUserId(User);
                Zgloszenie zgloszenie = new Zgloszenie
                {
                    Id = firstCommentVM.Id,
                    PostDate = DateTime.Now,
                    UserID = uzytkownikId,
                    CategoryId = firstCommentVM.CategoryId,
                    Topic = firstCommentVM.Topic,


                   // DepartmentId = BHPid,
                    AssignedToId = firstCommentVM.AssignedToId,
                    PriorityId = firstCommentVM.PriorityId,
                    Deadline = firstCommentVM.Deadline,
                    ClosedOn = firstCommentVM.ClosedOn,
                    WorkingAreaId = firstCommentVM.WorkingAreaId,
                    StatusByAssigned_Id = firstCommentVM.StatusByAssigned_Id,
                    StatusByPoster_Id = firstCommentVM.StatusByPoster_Id,
                };
                _zgloszenie.AddZgloszenie(zgloszenie);
                int zglo = zgloszenie.Id;
                Comments comments = new Comments
                {
                    AttachedToTaskId = zglo,
                    CommentedById = uzytkownikId,
                    CommentedOn = DateTime.Now,
                    Comment = firstCommentVM.Comment
                };
                _comments.AddComments(comments);

                //return RedirectToAction("Details", new { id = zgloszenie.Id });
                return RedirectToAction("Index");


            }
            return View();

        }

        //// GET: Comments/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Comments == null)
        //    {
        //        return NotFound();
        //    }

        //    var comments = await _context.Comments.FindAsync(id);
        //    if (comments == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["AttachedToTaskId"] = new SelectList(_context.Zgloszenies, "Id", "Id", comments.AttachedToTaskId);
        //    ViewData["CommentedById"] = new SelectList(_context.Users, "Id", "Id", comments.CommentedById);
        //    return View(comments);
        //}

        //// POST: Comments/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,AttachedToTaskId,CommentedById,CommentedOn,Comment")] Comments comments)
        //{
        //    if (id != comments.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(comments);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CommentsExists(comments.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["AttachedToTaskId"] = new SelectList(_context.Zgloszenies, "Id", "Id", comments.AttachedToTaskId);
        //    ViewData["CommentedById"] = new SelectList(_context.Users, "Id", "Id", comments.CommentedById);
        //    return View(comments);
        //}

        //// GET: Comments/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Comments == null)
        //    {
        //        return NotFound();
        //    }

        //    var comments = await _context.Comments
        //        .Include(c => c.AttachedToTask)
        //        .Include(c => c.CommentedBy)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (comments == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(comments);
        //}

        //// POST: Comments/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Comments == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Comments'  is null.");
        //    }
        //    var comments = await _context.Comments.FindAsync(id);
        //    if (comments != null)
        //    {
        //        _context.Comments.Remove(comments);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CommentsExists(int id)
        //{
        //  return _context.Comments.Any(e => e.Id == id);
        //}
    }
}
