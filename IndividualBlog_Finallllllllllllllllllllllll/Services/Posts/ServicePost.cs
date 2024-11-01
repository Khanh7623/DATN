using IndividualBlog.Data;
using IndividualBlog.Models;
using IndividualBlog.Models.ViewModel;
using IndividualBlog.Utilties.Common;
using IndividualBlog.Utilties.Enum;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualBlog.Services.Posts
{
    public class ServicePost : IServicePost
    {
        private readonly ApplicationDbContext context;
        private IWebHostEnvironment webHostEnvironment;
        public ServicePost(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<bool> Add(Post post, int[] categoryId, int[] tagId,IFormFile Image)
        {
            if (post == null)
            {
                return false;
            }
            string imagesName =string.Empty;
            if (Image == null || Image.Length == 0)
            {
                return false;
            }
            var path = Path.Combine(webHostEnvironment.WebRootPath, "upload/post", CommonFunction.UrlFriendly(post.Title)+"_"+Image.FileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            imagesName = await ProcessUploadedFile(post, Image);

            post.Image = imagesName;
            post.Slug = CommonFunction.UrlFriendly(post.Title);
            post.Created_At = DateTime.Now;
            post.Updated_At = DateTime.Now;
            post.Status = EPost.Approved;
            post.View = 0;
           

            context.ChangeTracker.Clear();
           await context.Posts.AddAsync(post);
           await context.SaveChangesAsync();

            List<PostInCategory> postInCategories = new List<PostInCategory>();
            for (int i = 0; i < categoryId.Length; i++)
            {
                postInCategories.Add(new
                PostInCategory()
                {
                    PostId = await GetMaxId(),
                    CategoryId = categoryId[i],
                });
            }
            List<TagInPost> tagInPosts = new List<TagInPost>();
            for (int i = 0; i < categoryId.Length; i++)
            {
                tagInPosts.Add(new
                TagInPost()
                {
                    PostId = await GetMaxId(),
                    TagId = tagId[i],
                });
            }

           await context.PostInCategories.AddRangeAsync(postInCategories);
           await context.TagInPosts.AddRangeAsync(tagInPosts);
           await context.SaveChangesAsync();
            return true;
        }
        public async Task<int> GetMaxId()
        {
            var max = await context.Posts.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            if(max == null)
            {
                return 1;
            }
               
            return max.Id;
        }
        public async Task<bool> Delete(int? id)
        {
            if(id == null)
            {
                return false;
            }
            var post = await context.Posts.FindAsync((int)id);
            if (post==null)
            {
                return false;
            }
            var CurrentImage = Path.Combine(webHostEnvironment.WebRootPath,"upload/post", CommonFunction.UrlFriendly(post.Title)+"_"+post.Image);
            context.Posts.Remove(post);
            if (await context.SaveChangesAsync() > 0)
            {
                if (File.Exists(CurrentImage))
                {
                   File.Delete(CurrentImage);
                }
            }
            return true;
        }
        //public async Task<List<Post>> GetAll()
        //{
        //    var result = await context.Posts.AsNoTracking()
        //        .Include(x => x.User)
        //        .OrderByDescending(x => x.Id)
        //        .ToListAsync();
        //    return result;
        //}
        public List<Post> GetAll()
        {
            var result =  context.Posts.AsNoTracking()
                .Include(x => x.User)
                .OrderByDescending(x => x.Id)
                .ToList();
            return result;
        }

        public async Task<Post> GetById(int? id)
        {
            var result = await context.Posts.Include(x => x.PostInCategories).ThenInclude(x => x.Category)
                .Include(x => x.User).ThenInclude(x => x.Posts)
                .Include(x => x.Comments).ThenInclude(x => x.User)
                .Include(x => x.TagInPosts).ThenInclude(x => x.Tag)
                .FirstOrDefaultAsync(x => x.Id == id && x.Status == EPost.Approved);
            return result;
        }

        //public Post GetById(int? id)
        //{
        //    var result =  context.Posts.Include(x => x.PostInCategories).ThenInclude(x => x.Category)
        //        .Include(x => x.User).ThenInclude(x => x.Posts)
        //        .Include(x => x.Comments).ThenInclude(x => x.User)
        //        .Include(x => x.TagInPosts).ThenInclude(x => x.Tag)
        //        .FirstOrDefault(x => x.Id == id);
        //    return result;
        //}

        public async Task<List<Post>> GetByCategoryId(int? categoryId)
        {
            var result = await context.Posts.OrderByDescending(x => x.Id)
                .Include(x => x.PostInCategories).ThenInclude(x => x.Category)
                .Include(x => x.User).ThenInclude(x => x.Posts)
                .Where(n => n.PostInCategories.Any(u => u.CategoryId == categoryId))
                .Take(10)
                .ToListAsync();
            return result;
        }
        public async Task<bool> Update(Post post,int id, int[] categoryId, int[] tagId, IFormFile Image)
        {
            if (post == null)
            {
                return false;
            }
            //var postInCategories = context.PostInCategories.Where(x => x.PostId == id && categoryId.Contains(x.CategoryId)).ToList();
           
            if (Image != null && Image.Length>0)
            {
                post.Image = await ProcessUploadedFile(post, Image); 
            }
            List<PostInCategory> postInCategories = new List<PostInCategory>();
            for (int i = 0; i < categoryId.Length; i++)
            {
                postInCategories.Add(new
                PostInCategory()
                {
                    PostId = id,
                    CategoryId = categoryId[i],
                });
            }
            List<TagInPost> tagInPosts = new List<TagInPost>();
            for (int i = 0; i < tagId.Length; i++)
            {
                tagInPosts.Add(new
                TagInPost()
                {
                    PostId = id,
                    TagId = tagId[i],
                });
            }
            
            var oldPost = await context.Posts.FirstOrDefaultAsync(x=>x.Id==id);
            // sửa lỗi
            if (post.Image != null) 
            { 
                post.Image = post.Image; 
            }
            else
            {
                post.Image = oldPost.Image;
            }
            post.Slug = CommonFunction.UrlFriendly(post.Title);
            post.Created_At = oldPost.Created_At;
            post.Updated_At = DateTime.Now;
            post.View = oldPost.View;
            
            context.PostInCategories.RemoveRange(context.PostInCategories.Where(x => x.PostId == id).ToList());
            context.TagInPosts.RemoveRange(context.TagInPosts.Where(x => x.PostId == id).ToList());
            await context.SaveChangesAsync();

            context.ChangeTracker.Clear();
            context.Posts.Update(post);
            //await context.SaveChangesAsync();
            await context.PostInCategories.AddRangeAsync(postInCategories);
            await context.TagInPosts.AddRangeAsync(tagInPosts);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<int> GetCategoryById(int id)
        {
            var result = await context.PostInCategories.Where(x=>x.PostId==id).FirstOrDefaultAsync();
            if(result == null)
            {
                return 0;
            }
            return result.CategoryId;
        }
        public async Task<string> ProcessUploadedFile(Post post, IFormFile Image)
        {
            string uniqueFileName = String.Empty;

            if (post.Image == null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "upload/post");
                uniqueFileName = CommonFunction.UrlFriendly(post.Title) + "_" + Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
            }
            else
            {
                uniqueFileName = post.Image;
            }
            
            return uniqueFileName;
        }

        //GetToHome
         public async Task<Post> GetOnePost()
        {
            var result =  await context.Posts.Include(x => x.PostInCategories).ThenInclude(x=>x.Category)
                .Include(x => x.User).ThenInclude(x => x.Posts)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Post>> GetPopularPost()
        {
            var result = await context.Posts.AsNoTracking().OrderByDescending(x => x.View).Take(4).ToListAsync();
            return result;
        }

        public async Task<List<Post>> GetRecentPost()
        {
            var result = await context.Posts.AsNoTracking().OrderByDescending(x => x.Id).Take(4).ToListAsync();
            return result;
        }

        public async Task<int> UpdateView(int id)
        {
            var oldPost = await context.Posts.FirstOrDefaultAsync(x => x.Id == id);
            oldPost.View = oldPost.View + 1;
            context.Posts.Update(oldPost);
            if( await context.SaveChangesAsync() < 0)
            {
                return 0;
            }
            return 1;
        }

        public async Task<Post> GetOneTrandingByCategory(int categoryId)
        {
            var result = await context.Posts.OrderByDescending(x=>x.View)
                .Include(x => x.PostInCategories).ThenInclude(x => x.Category)
                .Include(x => x.User).ThenInclude(x => x.Posts)
                .FirstOrDefaultAsync(n=>n.PostInCategories.Any(u=>u.CategoryId==categoryId));
            return result;
        }
        public async Task<List<Post>> GetTwoTrandingByCategory(int categoryId)
        {
            var result = await context.Posts.OrderByDescending(x => x.Id)
                .Include(x => x.PostInCategories).ThenInclude(x => x.Category)
                .Include(x => x.User).ThenInclude(x => x.Posts)
                .Where(n => n.PostInCategories.Any(u => u.CategoryId == categoryId))
                .ToListAsync();
            return result;
        }
        public async Task<List<Post>> GetToHome()
        {
            var result = await context.Posts.Include(x => x.PostInCategories).ThenInclude(x => x.Category)
                .Include(x => x.User).ThenInclude(x => x.Posts)
                .OrderByDescending(x=>x.Id).Take(8)
                .ToListAsync();
            return result;
        }
    }
}
