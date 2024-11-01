using IndividualBlog.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IndividualBlog.Services.Comments
{
    public interface IServiceComment
    {
       // Task<List<Comment>> GetAll();
        List<Comment> GetAll();
        //Task<Comment> GetById(int? id);
        Comment GetById(int? id);
        Task<int> Add(Comment comment);
        Task<int> Update(Comment comment, int? id);
        Task<bool> Delete(int? id);
    }
}
