using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndividualBlog.Models;
using IndividualBlog.Models.ViewModel;
using IndividualBlog.Services.UserService;
using IndividualBlog.Areas.Admin.Controllers.Base;
using IndividualBlog.Data;
using X.PagedList;
using IndividualBlog.Utilties.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.Eventing.Reader;

namespace IndividualBlog.Areas.Admin.Controllers
{
    
    public class UsersController : BaseController
    {
        private readonly IServiceUser serviceUser;
        private readonly ApplicationDbContext _context;
        public UsersController(IServiceUser serviceUser, ApplicationDbContext context)
        {
            _context = context;
            this.serviceUser = serviceUser;
        }
        public IActionResult Index(string SearchString, int? page, int id)
        {
            ViewData["CurrentFilter"] = SearchString;
            var timkiemuser = from a in _context.Users
                              select a;

            var pageNumber = page ?? 1;
            int pageSize = 3;
            var OnePageOfUsers = serviceUser.GetAll().ToPagedList(pageNumber, pageSize);

            if (!String.IsNullOrEmpty(SearchString))
            {
                timkiemuser = timkiemuser.Where(x => x.FirtName.Contains(SearchString));
                return View(timkiemuser.ToPagedList(pageNumber,pageSize));
            }
           // return View( serviceUser.GetAll());
            return View(OnePageOfUsers);
        }
        public IActionResult Details(int? id)
        {
            
            if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString())
            {

                if (id == null)
                {
                    return NotFound();
                }

                var user = serviceUser.GetById((int)id);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
            return Content("Tài khoản không có thẩm quyền để truy cập vào mục này");

        }
        public IActionResult Create()
        {
            //var status = new List<ViewModelUserStatus>()
            //{
            //    new ViewModelUserStatus(){Id =1,Status ="Active"},
            //    new ViewModelUserStatus(){Id =2,Status ="Block"}
            //};
            //var role = new List<ViewModelUserRole>()
            //{
            //    new ViewModelUserRole(){Id =1,Role ="Admin"},
            //    new ViewModelUserRole(){Id =2,Role ="Mod"},
            //    new ViewModelUserRole(){Id =3,Role ="Member"}
            //};

            //ViewData["Status"] = new SelectList(status, "Id", "Status");
            //ViewData["Role"] = new SelectList(role, "Id", "Role");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirtName,LastName,Email,Password,Avatar,Adress,Intro,Status,Role,Created_At,Updated_At")] User user)
        {
            if (ModelState.IsValid)
            {
                await serviceUser.AddUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

       
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var status = new List<ViewModelUserStatus>()
            //{
            //    new ViewModelUserStatus(){Id =1,Status ="Active"},
            //    new ViewModelUserStatus(){Id =2,Status ="Block"}
            //};
            //var role = new List<ViewModelUserRole>()
            //{
            //    new ViewModelUserRole(){Id =1,Role ="Admin"},
            //    new ViewModelUserRole(){Id =2,Role ="Mod"},
            //    new ViewModelUserRole(){Id =3,Role ="Member"}
            //};
            //int getStatus = (int)serviceUser.GetById((int)id).Status;
            //int getRole = (int)serviceUser.GetById((int)id).Role;

            //ViewData["Status"] = new SelectList(status, "Id", "Status",getStatus);
            //ViewData["Role"] = new SelectList(role, "Id", "Role", getRole);

            var user = serviceUser.GetById((int)id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirtName,LastName,Email,Password,Avatar,Adress,Intro,Status,Role,Created_At,Updated_At")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  await serviceUser.UpdateUser(user,id);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = serviceUser.GetById((int)id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
          await serviceUser.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return serviceUser.UserExists(id);
        }
    }
}
