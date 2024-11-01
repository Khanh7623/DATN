using IndividualBlog.Data;
using IndividualBlog.Models;
using IndividualBlog.Models.ViewModel;
using IndividualBlog.Services.Comments;
using IndividualBlog.Services.Posts;
using IndividualBlog.Services.UserService;
using IndividualBlog.Utilties.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServicePost servicePost;
        private readonly IServiceComment serviceComment;
        private readonly IServiceUser serviceUser;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, IServicePost servicePost, IServiceComment serviceComment, IServiceUser serviceUser, ApplicationDbContext context)
        {
            _logger = logger;
            this.servicePost = servicePost;
            this.serviceComment = serviceComment;
            this.serviceUser = serviceUser;
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var timkiem = _context.Posts.Where(x => x.Content.ToLower().Contains(searchString)).ToList();
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    searchString = searchString.ToLower();
            //    timkiem = timkiem.Where(x => x.Content.ToLower().Contains(searchString));
            //}
            ViewData["GetOnePost"] = await servicePost.GetOnePost();
            ViewData["GetPopularPost"] = await servicePost.GetPopularPost();
            ViewData["GetRecentPost"] = await servicePost.GetRecentPost();

            ViewData["GetOneTranding6"] =  await servicePost.GetOneTrandingByCategory(1);
            ViewData["GetTowTrending6"] = await servicePost.GetTwoTrandingByCategory(1);

            ViewData["GetOneTranding7"] = await servicePost.GetOneTrandingByCategory(2);
            ViewData["GetTowTrending7"] = await servicePost.GetTwoTrandingByCategory(2);
            var post = await servicePost.GetToHome();
            return View(post);
        }

		public IActionResult Info(int? id)
		{
                id = HttpContext.Session.GetInt32("UserId");
                if (id == null)
                {
                    return Content("Hãy đăng nhập!!!!");
                }

                var user = serviceUser.GetById((int)id);
                if (user == null)
                {
                return Content("Hãy đăng nhập!!!!");
                }
                
				return View(user);
        }
        public IActionResult EditAccount(int? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAccount(int id, [Bind("Id,FirtName,LastName,Email,Password,Avatar,Adress,Intro,Status,Role,Created_At,Updated_At")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await serviceUser.UpdateUser(user, id);
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
        private bool UserExists(int id)
        {
            return serviceUser.UserExists(id);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await servicePost.UpdateView((int)id);

            var post = await servicePost.GetById(id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        //public IActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    servicePost.UpdateView((int)id);

        //    var post = servicePost.GetById(id);
        //    if (post == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(post);
        //}

        [HttpPost]
        public async Task<IActionResult> Comment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.UserId = HttpContext.Session.GetInt32("UserId").Value;
                await serviceComment.Add(comment);
                return RedirectToAction(nameof(Index));
            }
            return View(comment);
        }
      
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ViewModelRegisterUser user)
        {
            if (ModelState.IsValid)
            {
                var result = await serviceUser.Register(user);
                if(result == -1)
                {
                    TempData["Register"] = "Chưa điền Email";
                    return View(user);
                }
                if (result > 0)
                {
                    TempData["Register"] = "Đăng ký Thành công";
                    return RedirectToAction("Login");
                }
            }
            TempData["Register"] = "Register Fail";
            return View(user);
        }
       
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("UserId") > 0)
            {
                return RedirectToAction("Index");
            }
            return View();

       
            
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(ViewModelLogin user)
        {
            
            if (user == null)
            {
                TempData["Login"] = "Null Data";
                return View();
            }

            var result =  await serviceUser.Login(user);
            if (result == null)
            {
                TempData["Login"] = "Đăng nhập thất bại";
                return View();
            }
            
            HttpContext.Session.SetInt32("UserId", result.Id);
            HttpContext.Session.SetString("FullName", result.FullName);
            HttpContext.Session.SetString("Role", result.Role.ToString());

            TempData["Login"] = "Login Success";
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
