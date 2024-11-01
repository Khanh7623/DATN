
using IndividualBlog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IndividualBlog.Services.Categories
{
    public interface IServiceCategory
    {
       // Task<List<Category>> GetAll();
        List<Category> GetAll();
       // Task<Category> GetById(int? id);
        Category GetById(int? id);
        Task<bool> Add(Category category);
        Task<bool> Update(Category category, int? id);
        Task<bool> Delete(int? id);

        //GettoSelect
        MultiSelectList GetToSelectByPost(int? postId);
        MultiSelectList GetToSelect();
    }
}
