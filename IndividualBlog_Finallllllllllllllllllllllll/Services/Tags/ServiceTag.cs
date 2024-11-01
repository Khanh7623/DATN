using IndividualBlog.Data;
using IndividualBlog.Models;
using IndividualBlog.Utilties.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualBlog.Services.Tags
{
    public class ServiceTag : IServiceTag
    {
        private readonly ApplicationDbContext context;
        public ServiceTag(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> Add(Tag tag)
        {
            if (tag == null)
            {
                return false;
            }
            tag.Slug = CommonFunction.UrlFriendly(tag.Name);
            await context.AddAsync(tag);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int? id)
        {
            if (id == null)
            {
                return false;
            }
            var result = await context.Tags.FindAsync(id);
            if (result == null)
            {
                return false;
            }
            context.Tags.Remove(result);
            await context.SaveChangesAsync();
            return true;
        }

        //public async Task<List<Tag>> GetAll()
        //{
        //    var result = await context.Tags.AsNoTracking()
        //        .OrderByDescending(x => x.Id).Take(10)
        //        .ToListAsync();
        //    return result;
        //}

        //public async Task<Tag> GetById(int? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        return null;
        //    }
        //    var result = await context.Tags.Where(x => x.Id == id)
        //        .FirstOrDefaultAsync();
        //    return result;
        //}

        public List<Tag> GetAll()
        {
            return context.Tags.OrderByDescending(x => x.Id).ToList();
        }

        public Tag GetById(int? id)
        {
            return context.Tags.FirstOrDefault(x => x.Id == id);
        }


        public async Task<bool> Update(Tag tag, int? id)
        {
            if (tag == null || id == null)
            {
                return false;
            }
            if (GetById(id) == null)
            {
                return false;
            }
            tag.Slug = CommonFunction.UrlFriendly(tag.Name);
            context.ChangeTracker.Clear();
            context.Tags.Update(tag);
            await context.SaveChangesAsync();
            return true;
        }
        public bool CheckExists(int id)
        {
            return context.Tags.Any(e => e.Id == id);
        }
        public MultiSelectList GetToSelect()
        {
           
           return new MultiSelectList(context.Set<Tag>(), "Id", "Name");     
        }
        public MultiSelectList GetToSelectByPost(int? postId)
        {
            if(postId == null)
            {
                return GetToSelect();
            }
            var getPostTag = context.TagInPosts.AsNoTracking().Where(x => x.PostId == postId).ToList();
            return new MultiSelectList(context.Set<Tag>(), "Id", "Name", getPostTag.Select(x=>x.TagId));
        }
    }
}
