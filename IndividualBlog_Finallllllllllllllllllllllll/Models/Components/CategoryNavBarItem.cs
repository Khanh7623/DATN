﻿using IndividualBlog.Services.Categories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IndividualBlog.Models.Components
{
    public class CategoryNavBarItem : ViewComponent
    {
        private readonly IServiceCategory serviceCategory;

        public CategoryNavBarItem(IServiceCategory serviceCategory)
        {
            this.serviceCategory = serviceCategory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
          //  var result = await serviceCategory.GetAll();
            var result =  serviceCategory.GetAll();
            return View(result);
        }
    }
}