using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndividualBlog.Data;
using IndividualBlog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using IndividualBlog.Utilties.Common;
using IndividualBlog.Utilties.Enum;
using IndividualBlog.Services.Posts;
using IndividualBlog.Models.ViewModel;
using IndividualBlog.Services.Categories;
using IndividualBlog.Services.Tags;
using IndividualBlog.Areas.Admin.Controllers.Base;
using X.PagedList;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IndividualBlog.Areas.Admin.Controllers
{
    
    public class PostsController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IServicePost servicePost;
        private readonly IServiceCategory serviceCategory;
        private readonly IServiceTag serviceTag;
        public PostsController(ApplicationDbContext context, IServicePost servicePost, IServiceCategory serviceCategory, IServiceTag serviceTag)
        {
            _context = context;
            this.servicePost = servicePost;
            this.serviceCategory = serviceCategory;
            this.serviceTag = serviceTag;
        }

        // GET: Admin/Posts
        //public async Task<IActionResult> Index( string SearchString)
        //{
        //    ViewData["CurrentFilter"] = SearchString;
        //    var timkiempost = from a in _context.Posts
        //                      select a;
        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        timkiempost = timkiempost.Where(x => x.Title.Contains(SearchString)).Where(x => x.Content.Contains(SearchString)).Where(x=> x.Summary.Contains(SearchString));
        //        return View(timkiempost);
        //    }
        //    return View(await servicePost.GetAll());
        //}
        public IActionResult Index(string SearchString, int? page)
        {
            ViewData["CurrentFilter"] = SearchString;
            var timkiempost = from a in _context.Posts
                              select a;
            var pageNumber = page ?? 1;
            int pageSize = 5;
            var OnePageOfPosts = servicePost.GetAll().ToPagedList(pageNumber, pageSize);

            if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString() || HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Mod.ToString())
            {
                if (!String.IsNullOrEmpty(SearchString))
                {
                    timkiempost = timkiempost.Where(x => x.Title.Contains(SearchString)).Where(x => x.Content.Contains(SearchString)).Where(x => x.Summary.Contains(SearchString));
                    return View(timkiempost.ToPagedList(pageNumber, pageSize));
                }
                return View(OnePageOfPosts);
            }
            return Content("Tài khoản không có thẩm quyền để truy cập vào mục này");


           
        }

        // GET: Admin/Posts/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var post = await _context.Posts
        //        .Include(p => p.User)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (post == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(post);
        //}

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post =  _context.Posts
                .Include(p => p.User)
                .FirstOrDefault(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Admin/Posts/Create
        public IActionResult Create()
        {
            
            ViewData["Category"] = serviceCategory.GetToSelect();
            ViewData["Tag"] = serviceTag.GetToSelect();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Post post, IFormFile Image,int[] categoryId,int[] tagId)
        {
            if (ModelState.IsValid)
            {
                post.UserId = HttpContext.Session.GetInt32("UserId").Value;
                var resualt = await servicePost.Add(post,categoryId,tagId,Image);
                if (resualt)
                {
                    return RedirectToAction(nameof(Index));
                }
               
            }
            TempData["Alert"] = "Them that bai ...!";
            return View(post);
        }

        // GET: Admin/Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }


            ViewData["Category"] = serviceCategory.GetToSelectByPost(id);
            ViewData["Tag"] = serviceTag.GetToSelectByPost(id);

            //List<ViewModelStatus> status = new List<ViewModelStatus>()
            //{
            //    new ViewModelStatus(){Id =0,Status ="Hiển thị"},
            //    new ViewModelStatus(){Id =1,Status ="Ẩn bài"}
            //};
            //int getStatus = (int)servicePost.GetById(id).Status;
            //ViewData["Status"] = new SelectList(status, "Id", "Status", getStatus);
            ViewBag.Image = serviceCategory.GetById(id);
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Post post, IFormFile Image, int[] categoryId,int[] tagId)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    post.UserId = HttpContext.Session.GetInt32("UserId").Value;
                    await servicePost.Update(post,id,categoryId,tagId,Image);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return NoContent();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category"] = new MultiSelectList(_context.Set<Category>(), "Id", "Title", categoryId);
            ViewData["Tag"] = new MultiSelectList(_context.Set<Tag>(), "Id", "Title", tagId);
            ViewBag.Image = serviceCategory.GetById(id);
            return View(post);
        }

        // GET: Admin/Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await servicePost.GetById(id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        //public IActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var post = servicePost.GetById(id);
        //    if (post == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(post);
        //}

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int? page)
        {
			
			await servicePost.Delete(id);
			return RedirectToAction(nameof(Index));
			
		}

        private bool PostExists(int id)
        {
            return servicePost.GetById(id) != null;
        }
    }
}
