using IndividualBlog.Data;
using IndividualBlog.Models;
using IndividualBlog.Utilties.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualBlog.Services.Categories
{
    public class ServiceCategory : IServiceCategory
    {
        private readonly ApplicationDbContext context;
        public ServiceCategory(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> Add(Category category)
        {
            if (category == null)
            {
                return false;
            }
            category.Slug = CommonFunction.UrlFriendly(category.Title);
            category.Created_At = DateTime.Now;
            category.Updated_At = DateTime.Now;
            await context.AddAsync(category);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int? id)
        {
            if(id == null)
            {
                return false;
            }
            var result = await context.Categories.FindAsync(id);
            if (result==null)
            {
                return false;
            }
            context.Categories.Remove(result);
            await context.SaveChangesAsync();
            return true;
        }

		//public async Task<List<Category>> GetAll()
		//{
		//    var result = await context.Categories.AsNoTracking()
		//        .OrderByDescending(x=>x.Id).Take(10)
		//        .ToListAsync();
		//    return result;
		//}

		//public async Task<Category> GetById(int? id)
		//{
		//   if (!id.HasValue)
		//    {
		//        return null;
		//    }
		//    var result = await context.Categories.Where(x=>x.Id==id)
		//        .FirstOrDefaultAsync();
		//    return result;

		//}
		public List<Category> GetAll()
		{
			return context.Categories.OrderByDescending(x => x.Id).ToList();
		}

		public Category GetById(int? id)
		{
			return context.Categories.FirstOrDefault(x => x.Id == id);
		}


		public async Task<bool> Update(Category category, int? id)
        {
            if(category == null || id==null)
            {
                return false;
            }
            if (GetById(id)==null)
            {
                return false;
            }
            category.Slug = CommonFunction.UrlFriendly(category.Title);
            category.Updated_At = DateTime.Now;
            context.ChangeTracker.Clear();
            context.Categories.Update(category);
            
            await context.SaveChangesAsync();
            return true;
        }
        public MultiSelectList GetToSelectByPost(int? postId)
        {

            if (postId == null)
            {
                return GetToSelect();
            }
            var getPostCategories = context.PostInCategories.AsNoTracking().Where(x => x.PostId == postId).ToList();
            return new MultiSelectList(context.Set<Category>(), "Id", "Title", getPostCategories.Select(x=>x.CategoryId));
        }
        public MultiSelectList GetToSelect()
        {

            return new MultiSelectList(context.Set<Category>(), "Id", "Title");
        }

    }
}
