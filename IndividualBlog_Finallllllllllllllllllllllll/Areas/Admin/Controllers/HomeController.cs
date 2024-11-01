using IndividualBlog.Areas.Admin.Controllers.Base;
using IndividualBlog.Utilties.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndividualBlog.Areas.Admin.Controllers
{
   
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Admin.ToString() || HttpContext.Session.GetInt32("UserId") > 0 && HttpContext.Session.GetString("Role") == EUserRole.Mod.ToString())
            {
                return View();
            }
           return Content("Tài khoản không được phép truy cập!!!!!");
                
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
