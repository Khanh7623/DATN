using IndividualBlog.Services.Tags;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IndividualBlog.Models.Components
{
    public class WigetTag : ViewComponent
    {
        private readonly IServiceTag serviceTag;

        public WigetTag(IServiceTag serviceTag)
        {
            this.serviceTag = serviceTag;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result =  serviceTag.GetAll();
            return View(result);
        }
        //public IViewComponentResult InvokeAsync()
        //{
        //    var result =  serviceTag.GetAll();
        //    return View(result);
        //}
    }
}
