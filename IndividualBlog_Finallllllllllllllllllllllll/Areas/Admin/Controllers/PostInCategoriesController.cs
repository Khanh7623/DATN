using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndividualBlog.Data;
using IndividualBlog.Models;
using IndividualBlog.Areas.Admin.Controllers.Base;

namespace IndividualBlog.Areas.Admin.Controllers
{
   
    public class PostInCategoriesController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public PostInCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/PostInCategories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PostInCategories.Include(p => p.Category).Include(p => p.Post);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/PostInCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postInCategory = await _context.PostInCategories
                .Include(p => p.Category)
                .Include(p => p.Post)
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (postInCategory == null)
            {
                return NotFound();
            }

            return View(postInCategory);
        }

        // GET: Admin/PostInCategories/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Slug");
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Content");
            return View();
        }

        // POST: Admin/PostInCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,CategoryId")] PostInCategory postInCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postInCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Slug", postInCategory.CategoryId);
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Content", postInCategory.PostId);
            return View(postInCategory);
        }

        // GET: Admin/PostInCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postInCategory = await _context.PostInCategories.FindAsync(id);
            if (postInCategory == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Slug", postInCategory.CategoryId);
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Content", postInCategory.PostId);
            return View(postInCategory);
        }

        // POST: Admin/PostInCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,CategoryId")] PostInCategory postInCategory)
        {
            if (id != postInCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postInCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostInCategoryExists(postInCategory.CategoryId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Slug", postInCategory.CategoryId);
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Content", postInCategory.PostId);
            return View(postInCategory);
        }

        // GET: Admin/PostInCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postInCategory = await _context.PostInCategories
                .Include(p => p.Category)
                .Include(p => p.Post)
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (postInCategory == null)
            {
                return NotFound();
            }

            return View(postInCategory);
        }

        // POST: Admin/PostInCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postInCategory = await _context.PostInCategories.FindAsync(id);
            _context.PostInCategories.Remove(postInCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostInCategoryExists(int id)
        {
            return _context.PostInCategories.Any(e => e.CategoryId == id);
        }
    }
}
