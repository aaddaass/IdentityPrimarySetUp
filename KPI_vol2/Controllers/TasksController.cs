using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KPI_vol2.Data;
using KPI_vol2.Models;

namespace KPI_vol2.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tasks.Include(t => t.AssignedTo).Include(t => t.Category).Include(t => t.Department).Include(t => t.PostedBy).Include(t => t.Priority).Include(t => t.StatusByAssigned).Include(t => t.StatusByPoster).Include(t => t.WorkingArea);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks
                .Include(t => t.AssignedTo)
                .Include(t => t.Category)
                .Include(t => t.Department)
                .Include(t => t.PostedBy)
                .Include(t => t.Priority)
                .Include(t => t.StatusByAssigned)
                .Include(t => t.StatusByPoster)
                .Include(t => t.WorkingArea)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            ViewData["AssignedToId"] = new SelectList(_context.Users, "Id", "UserName");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            ViewData["PosterId"] = new SelectList(_context.Users, "Id", "UserName");
            ViewData["PriorityId"] = new SelectList(_context.Set<Priorities>(), "Id", "Name");
            ViewData["StatusByAssignedId"] = new SelectList(_context.AssignerStatus, "Id", "Name");
            ViewData["StatusByPosterId"] = new SelectList(_context.PosterStatus, "Id", "Name");
            ViewData["WorkingAreaId"] = new SelectList(_context.WorkingAreas, "Id", "Name");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PostDate,PosterId,CategoryId,Topic,DepartmentId,AssignedToId,PriorityId,Deadline,StatusByPosterId,StatusByAssignedId,ClosedOn,WorkingAreaId")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tasks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignedToId"] = new SelectList(_context.Users, "Id", "Id", tasks.AssignedToId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", tasks.CategoryId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", tasks.DepartmentId);
            ViewData["PosterId"] = new SelectList(_context.Users, "Id", "Id", tasks.PosterId);
            ViewData["PriorityId"] = new SelectList(_context.Set<Priorities>(), "Id", "Id", tasks.PriorityId);
            ViewData["StatusByAssignedId"] = new SelectList(_context.AssignerStatus, "Id", "Id", tasks.StatusByAssignedId);
            ViewData["StatusByPosterId"] = new SelectList(_context.PosterStatus, "Id", "Id", tasks.StatusByPosterId);
            ViewData["WorkingAreaId"] = new SelectList(_context.WorkingAreas, "Id", "Id", tasks.WorkingAreaId);
            return View(tasks);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }
            ViewData["AssignedToId"] = new SelectList(_context.Users, "Id", "Id", tasks.AssignedToId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", tasks.CategoryId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", tasks.DepartmentId);
            ViewData["PosterId"] = new SelectList(_context.Users, "Id", "Id", tasks.PosterId);
            ViewData["PriorityId"] = new SelectList(_context.Set<Priorities>(), "Id", "Id", tasks.PriorityId);
            ViewData["StatusByAssignedId"] = new SelectList(_context.AssignerStatus, "Id", "Id", tasks.StatusByAssignedId);
            ViewData["StatusByPosterId"] = new SelectList(_context.PosterStatus, "Id", "Id", tasks.StatusByPosterId);
            ViewData["WorkingAreaId"] = new SelectList(_context.WorkingAreas, "Id", "Id", tasks.WorkingAreaId);
            return View(tasks);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PostDate,PosterId,CategoryId,Topic,DepartmentId,AssignedToId,PriorityId,Deadline,StatusByPosterId,StatusByAssignedId,ClosedOn,WorkingAreaId")] Tasks tasks)
        {
            if (id != tasks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tasks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TasksExists(tasks.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignedToId"] = new SelectList(_context.Users, "Id", "Id", tasks.AssignedToId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", tasks.CategoryId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id", tasks.DepartmentId);
            ViewData["PosterId"] = new SelectList(_context.Users, "Id", "Id", tasks.PosterId);
            ViewData["PriorityId"] = new SelectList(_context.Set<Priorities>(), "Id", "Id", tasks.PriorityId);
            ViewData["StatusByAssignedId"] = new SelectList(_context.AssignerStatus, "Id", "Id", tasks.StatusByAssignedId);
            ViewData["StatusByPosterId"] = new SelectList(_context.PosterStatus, "Id", "Id", tasks.StatusByPosterId);
            ViewData["WorkingAreaId"] = new SelectList(_context.WorkingAreas, "Id", "Id", tasks.WorkingAreaId);
            return View(tasks);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var tasks = await _context.Tasks
                .Include(t => t.AssignedTo)
                .Include(t => t.Category)
                .Include(t => t.Department)
                .Include(t => t.PostedBy)
                .Include(t => t.Priority)
                .Include(t => t.StatusByAssigned)
                .Include(t => t.StatusByPoster)
                .Include(t => t.WorkingArea)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tasks == null)
            {
                return NotFound();
            }

            return View(tasks);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tasks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tasks'  is null.");
            }
            var tasks = await _context.Tasks.FindAsync(id);
            if (tasks != null)
            {
                _context.Tasks.Remove(tasks);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TasksExists(int id)
        {
          return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
