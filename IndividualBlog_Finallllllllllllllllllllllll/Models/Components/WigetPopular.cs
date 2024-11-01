using IndividualBlog.Services.Posts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IndividualBlog.Models.Components
{
    public class WigetPopular : ViewComponent
    {
        private readonly IServicePost servicePost;

        public WigetPopular(IServicePost servicePost)
        {
            this.servicePost = servicePost;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await servicePost.GetPopularPost();
            return View(result);
        }
    }
}
