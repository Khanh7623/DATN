using IndividualBlog.Data;
using IndividualBlog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualBlog.Services.Comments
{
    public class ServiceComment : IServiceComment
    {
        private readonly ApplicationDbContext context;
        public ServiceComment(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Add(Comment comment)
        {

            comment.Created_At = DateTime.Now;
            comment.Updated_At = DateTime.Now;

            await context.AddAsync(comment);
            if(await context.SaveChangesAsync() > 0)
            {
                return 1;
            }
            return 0;
        }

        public async Task<bool> Delete(int? id)
        {
            var result =  await context.Comments.FindAsync(id);
            if(result == null)
            {
                return false;
            }
            context.Comments.Remove(result);
          if( await context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        //public async Task<List<Comment>> GetAll()
        //{
        //    var result = await context.Comments.AsNoTracking()
        //        .OrderByDescending(x => x.Id).Take(10)
        //        .ToListAsync();
        //    return result;
        //}

        public List<Comment> GetAll()
        {
            var result =  context.Comments.AsNoTracking().Include(x=> x.User).Include(x=>x.Post)
                .OrderByDescending(x => x.Id).Take(10)
                .ToList();
            return result;
        }
        


        //public async Task<Comment> GetById(int? id)
        //{
        //    return await context.Comments
        //        .Include(x => x.User).ThenInclude(x => x.Comments)
        //        .Include(x => x.Post).ThenInclude(x => x.Comments)
        //        .FirstOrDefaultAsync(x=>x.Id==id);
        //}

        public Comment GetById(int? id)
        {
            return  context.Comments
                .Include(x => x.User).ThenInclude(x => x.Comments)
                .Include(x => x.Post).ThenInclude(x => x.Comments)
                .FirstOrDefault(x => x.Id == id);
        }


        public async Task<int> Update(Comment category, int? id)
        {
            var oldComment = await context.Comments.FindAsync((int)id);
            if(oldComment == null)
            {
                return 0;
            }
            oldComment.Content = category.Content;
            oldComment.Updated_At = DateTime.Now;
            context.Comments.Update(oldComment);
            if(await context.SaveChangesAsync() > 0)
            {
                return 1;
            }
            return 0;
        }
    }
}
