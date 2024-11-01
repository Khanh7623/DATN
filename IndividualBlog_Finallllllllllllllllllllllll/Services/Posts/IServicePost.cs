using IndividualBlog.Models;
using IndividualBlog.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IndividualBlog.Services.Posts
{
    public interface IServicePost
    {
      //  Task<List<Post>> GetAll();
        List<Post> GetAll();
        Task<Post> GetById(int? id);
        //Post GetById(int? id);
        Task<bool> Add(Post post, int[] categoryId, int[] tagId, IFormFile Image);
        Task<bool> Update(Post post, int id,int[] categoryId, int[] tagId, IFormFile Image);
        Task<bool> Delete(int? id);
        Task<int> GetMaxId();
        Task<int> GetCategoryById(int id);
        Task<List<Post>> GetByCategoryId(int? categoryId);

        //
        Task<Post> GetOnePost();
        Task<List<Post>> GetPopularPost();
        Task<List<Post>> GetRecentPost();
        Task<int> UpdateView(int id);

        Task<List<Post>> GetTwoTrandingByCategory(int categoryId);
        Task<Post> GetOneTrandingByCategory(int categoryId);
        Task<List<Post>> GetToHome();

    }
}
