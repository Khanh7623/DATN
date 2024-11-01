using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndividualBlog.Data;
using IndividualBlog.Models;
using IndividualBlog.Services.Tags;
using IndividualBlog.Areas.Admin.Controllers.Base;
using IndividualBlog.Services.Categories;
using IndividualBlog.Utilties.Enum;
using Microsoft.AspNetCore.Http;
using IndividualBlog.Services.UserService;
using X.PagedList;

namespace IndividualBlog.Areas.Admin.Controllers
{
    
    public class TagsController : BaseController
    {
        private readonly IServiceTag serviceTag;
        private readonly ApplicationDbContext _context;

        public TagsController(IServiceTag serviceTag, ApplicationDbContext context)
        {
            this.serviceTag = serviceTag;
            _context = context;
        }

        //public async Task<IActionResult> Index(string SearchString, int? page)
        //{
        //    ViewData["CurrentFilter"] = SearchString;
        //    var timkiemtag = from a in _context.Tags
        //                     select a;
        //    var pageNumber = page ?? 1;
        //    int pageSize = 3;
        //    var OnePageOfTags = serviceTag.GetAll().ToPagedList(pageNumber, pageSize);
        //    // return View(serviceTag.GetAll());
        //    if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString())
        //    {
        //        if (!String.IsNullOrEmpty(SearchString))
        //        {
        //            timkiemtag = timkiemtag.Where(x => x.Name.Contains(SearchString));
        //            return View(timkiemtag);
        //        }
        //        return View(await serviceTag.GetAll());
        //    }
        //    return Content("Tài khoản không có thẩm quyền để truy cập vào mục này");
        //    // return Redirect("./");
        //}

        public IActionResult Index(string SearchString, int? page)
        {
            ViewData["CurrentFilter"] = SearchString;
            var timkiemtag = from a in _context.Tags
                             select a;
            var pageNumber = page ?? 1;
            int pageSize = 5;
            var OnePageOfTags = serviceTag.GetAll().ToPagedList(pageNumber, pageSize);
            if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString() || HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Mod.ToString())
            {
                if (!String.IsNullOrEmpty(SearchString))
                {
                    timkiemtag = timkiemtag.Where(x => x.Name.Contains(SearchString));
                    return View(timkiemtag.ToPagedList(pageNumber,pageSize));
                }
                return View(OnePageOfTags);
            }
            return Content("Tài khoản không có thẩm quyền để truy cập vào mục này");
            // return Redirect("./");
        }


        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString())
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }
        //        var category = await serviceTag.GetById(id);
        //        if (category == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(category);
        //    }
        //    return Redirect("./");


        //    //if (id == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //var tag = await serviceTag.GetById(id);
        //    //if (tag == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //return View(tag);
        //}
        public IActionResult Details(int? id)
        {
            if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString())
            {
                if (id == null)
                {
                    return NotFound();
                }
                var category = serviceTag.GetById(id);
                if (category == null)
                {
                    return NotFound();
                }

                return View(category);
            }
            return Content("Tài khoản không có thẩm quyền để truy cập vào mục này");


            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var tag = await serviceTag.GetById(id);
            //if (tag == null)
            //{
            //    return NotFound();
            //}

            //return View(tag);
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString())
            {
                return View();
            }
            // return Redirect("./");
            return Content("Tài khoản không có thẩm quyền để truy cập vào mục này");
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Slug")] Tag tag)
        {


            if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString())
            {
                if (ModelState.IsValid)
                {
                    await serviceTag.Add(tag);
                    return RedirectToAction(nameof(Index));
                }
                return View(tag);
            }
            return Content("Tài khoản không có thẩm quyền để truy cập vào mục này");
        }
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString())
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }
        //        var tag = await serviceTag.GetById(id);
        //        if (tag == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(tag);
        //    }
        //    return Content("Tài khoản không có thẩm quyền để truy cập vào mục này");
        //    //if (id == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //var tag = await serviceTag.GetById(id.Value);
        //    //if (tag == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    //return View(tag);
        //}
        public IActionResult Edit(int? id)
        {
            if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString())
            {
                if (id == null)
                {
                    return NotFound();
                }
                var tag = serviceTag.GetById(id);
                if (tag == null)
                {
                    return NotFound();
                }

                return View(tag);
            }
            return Content("Tài khoản không có thẩm quyền để truy cập vào mục này");
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var tag = await serviceTag.GetById(id.Value);
            //if (tag == null)
            //{
            //    return NotFound();
            //}
            //return View(tag);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Tag tag)
        {
            if (id != tag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   if(!await serviceTag.Update(tag, id))
                    {
                        TempData["Alert"] = "Update Tag error...!";
                        return View(tag);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagExists(tag.Id))
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
            return View(tag);
        }

        // GET: Admin/Tags/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString())
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }
        //        var tag = await serviceTag.GetById(id);
        //        if (tag == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(tag);
        //    }
        //    return Content("Tài khoản không có thẩm quyền để truy cập vào mục này");
        //    //if (id == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //var tag = await serviceTag.GetById(id.Value);
        //    //if (tag == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //return View(tag);
        //}

        public IActionResult Delete(int? id)
        {
            if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString())
            {
                if (id == null)
                {
                    return NotFound();
                }
                var tag =  serviceTag.GetById(id);
                if (tag == null)
                {
                    return NotFound();
                }

                return View(tag);
            }
            return Content("Tài khoản không có thẩm quyền để truy cập vào mục này");
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var tag = await serviceTag.GetById(id.Value);
            //if (tag == null)
            //{
            //    return NotFound();
            //}

            //return View(tag);
        }


        // POST: Admin/Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
           if(id == null)
            {
                TempData["Alert"] = "Xoa That bai";
                return RedirectToAction(nameof(Index));
            }
            await serviceTag.Delete(id.Value);
            TempData["Alert"] = "Thanh cong...!";
            return RedirectToAction(nameof(Index));
        }

        private bool TagExists(int id)
        {
            return serviceTag.CheckExists(id);
        }
    }
}
