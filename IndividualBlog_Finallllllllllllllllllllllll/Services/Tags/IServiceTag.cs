using IndividualBlog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IndividualBlog.Services.Tags
{
    public interface IServiceTag
    {
       // Task<List<Tag>> GetAll();
        List<Tag> GetAll();

        //  Task<Tag> GetById(int? id);
        Tag GetById(int? id);
        Task<bool> Add(Tag tag);
        Task<bool> Update(Tag tag, int? id);
        Task<bool> Delete(int? id);
        bool CheckExists(int id);
        ////
        MultiSelectList GetToSelectByPost(int? postId);
       // MultiSelectList GetToSelectWithCalue(int[] values);
        MultiSelectList GetToSelect();
    }
}
