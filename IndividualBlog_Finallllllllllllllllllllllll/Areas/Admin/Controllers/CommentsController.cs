using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndividualBlog.Data;
using IndividualBlog.Models;
using IndividualBlog.Services.Comments;
using IndividualBlog.Areas.Admin.Controllers.Base;
using IndividualBlog.Services.Categories;
using IndividualBlog.Utilties.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace IndividualBlog.Areas.Admin.Controllers
{
   
    public class CommentsController : BaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceComment serviceComment;

        public CommentsController(ApplicationDbContext context, IServiceComment serviceComment)
        {
            _context = context;
            this.serviceComment = serviceComment;
        }
        //public async Task<IActionResult> Index()
        //{
        //    var result = await serviceComment.GetAll();
        //    return View(result);
        //}
        public IActionResult Index(string SearchString, int? page)
        {
            ViewData["CurrentFilter"] = SearchString;
            var timkiemcomment = from a in _context.Categories
                                  select a;
            var pageNumber = page ?? 1;
            int pageSize = 3;
            var OnePageOfComments = serviceComment.GetAll().ToPagedList(pageNumber, pageSize);
            if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString() || HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Mod.ToString())
            {
                if (!String.IsNullOrEmpty(SearchString))
                {
                    timkiemcomment = timkiemcomment.Where(x => x.Description.Contains(SearchString)).Where(x => x.Title.Contains(SearchString));
                    return View(timkiemcomment.ToPagedList(pageNumber, pageSize));
                }
                return View(OnePageOfComments);
            }
            //return Redirect("./");
            return Content("Tài khoản không có thẩm quyền để truy cập vào mục này");
        }


        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var comment = await serviceComment.GetById(id);
        //    if (comment == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(comment);
        //}

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment =  serviceComment.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
