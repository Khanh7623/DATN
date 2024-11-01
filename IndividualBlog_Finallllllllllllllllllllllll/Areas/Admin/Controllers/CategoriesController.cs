using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndividualBlog.Data;
using IndividualBlog.Models;
using IndividualBlog.Utilties.Common;
using System.Web;
using IndividualBlog.Services.Categories;
using IndividualBlog.Areas.Admin.Controllers.Base;
using Microsoft.AspNetCore.Http;
using IndividualBlog.Utilties.Enum;
using IndividualBlog.Services.Tags;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace IndividualBlog.Areas.Admin.Controllers
{
    
    public class CategoriesController : BaseController
    {
        private readonly IServiceCategory serviceCategory;
        private readonly ApplicationDbContext _context;
        public CategoriesController(IServiceCategory serviceCategory, ApplicationDbContext context)
        {
            this.serviceCategory = serviceCategory;
            _context = context;
        }

        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    ViewData["CurrentFilter"] = SearchString;
        //    var timkiemcategory = from a in _context.Categories
        //                          select a;
        //    if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString())
        //    {
        //        if (!String.IsNullOrEmpty(SearchString))
        //        {
        //            timkiemcategory = timkiemcategory.Where(x => x.Description.Contains(SearchString));
        //            return View(timkiemcategory);
        //        }
        //        return View(await serviceCategory.GetAll());
        //    }
        //    //return Redirect("./");
        //    return Content("Tài khoản không có thẩm quyền để truy cập vào mục này");
        //}
		public IActionResult Index(string SearchString, int? page)
		{
			ViewData["CurrentFilter"] = SearchString;
			var timkiemcategory = from a in _context.Categories
								  select a;
            var pageNumber = page ?? 1;
            int pageSize = 5;
            var OnePageOfCategories = serviceCategory.GetAll().ToPagedList(pageNumber, pageSize);
            if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString() || HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Mod.ToString())
			{
				if (!String.IsNullOrEmpty(SearchString))
				{
					timkiemcategory = timkiemcategory.Where(x => x.Description.Contains(SearchString)).Where(x=> x.Title.Contains(SearchString));
					return View(timkiemcategory.ToPagedList(pageNumber, pageSize));
				}
				return View(OnePageOfCategories);
			}
			//return Redirect("./");
			return Content("Tài khoản không có thẩm quyền để truy cập vào mục này");
		}




		//public async Task<IActionResult> Details(int? id)
  //      {
  //          if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString())
  //          {
  //              if (id == null)
  //              {
  //                  return NotFound();
  //              }
  //              var category = await serviceCategory.GetById(id);
  //              if (category == null)
  //              {
  //                  return NotFound();
  //              }

  //              return View(category);
  //          }
  //          return Content("Tài khoản không có thẩm quyền để truy cập vào mục này");
  //          //return Redirect("./");

  //      }
		public IActionResult Details(int? id)
		{

			if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString())
			{
				if (id == null)
				{
					return NotFound();
				}
				var category = serviceCategory.GetById(id);
				if (category == null)
				{
					return NotFound();
				}

				return View(category);
			}
			return Content("Tài khoản không có thẩm quyền để truy cập vào mục này");
			//return Redirect("./");

		}

		public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString())
            {
                return View();
            }
            return Redirect("./");
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await serviceCategory.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString())
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }
        //        var category = await serviceCategory.GetById(id);
        //        if (category == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(category);
        //    }
        //    return Content("Tài khoản không có thẩm quyền để truy cập vào mục này");


        //    //if (id == null)
        //    //{
        //    //    return NotFound();
        //    //}

        //    //var category = await serviceCategory.GetById(id);
        //    //if (category == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    //return View(category);
        //}

		public IActionResult Edit(int? id)
		{
			if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString())
			{
				if (id == null)
				{
					return NotFound();
				}
				var category = serviceCategory.GetById(id);
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

			//var category = await serviceCategory.GetById(id);
			//if (category == null)
			//{
			//    return NotFound();
			//}
			//return View(category);
		}


		// POST: Admin/Categories/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(!await serviceCategory.Update(category, id))
                    {
                        TempData["Alert"] = "Update Category error...!";
                        return View(category);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

		//public async Task<IActionResult> Delete(int? id)
		//{
		//    if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString())
		//    {
		//        if (id == null)
		//        {
		//            return NotFound();
		//        }
		//        var category = await serviceCategory.GetById(id);
		//        if (category == null)
		//        {
		//            return NotFound();
		//        }

		//        return View(category);
		//    }
		//    return Content("Tài khoản không có thẩm quyền để truy cập vào mục này");
		//    //if (id == null)
		//    //{
		//    //    return NotFound();
		//    //}

		//    //var category = await serviceCategory.GetById(id);
		//    //if (category == null)
		//    //{
		//    //    return NotFound();
		//    //}

		//    //return View(category);
		//}
		public IActionResult Delete(int? id)
		{
			if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString())
			{
				if (id == null)
				{
					return NotFound();
				}
				var category =  serviceCategory.GetById(id);
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

			//var category = await serviceCategory.GetById(id);
			//if (category == null)
			//{
			//    return NotFound();
			//}

			//return View(category);
		}

		// POST: Admin/Categories/Delete/5
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await serviceCategory.Delete(id);
            if (category)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        private bool CategoryExists(int id)
        {
            var result = serviceCategory.GetById(id);
            if (result == null)
            {
                return true;
            }
            return false;
        }
    }
}
