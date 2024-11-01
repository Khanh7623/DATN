using IndividualBlog.Models;
using IndividualBlog.Services.Categories;
using IndividualBlog.Services.Posts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IndividualBlog.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IServiceCategory serviceCategory;
        private readonly IServicePost servicePost;
        public CategoriesController(IServiceCategory serviceCategory, IServicePost servicePost)
        {
           
            this.serviceCategory = serviceCategory;
            this.servicePost = servicePost;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if(id == null)
            {
                var post1 = await servicePost.GetToHome();
                return View(post1);
            }
            var post = await servicePost.GetByCategoryId((int)id);
            return View(post);

        }
    }
}
