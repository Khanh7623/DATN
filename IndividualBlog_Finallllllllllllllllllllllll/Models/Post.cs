using IndividualBlog.Utilties.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IndividualBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        public string Slug { get; set; }
        [Display(Name = "Mô tả")]
        public string Summary { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Ảnh đại diện")]
        public string Image { get; set; }
        [Display(Name = "Trạng thái")]
        public EPost Status { get; set; } = EPost.Approved;
        public int View { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime Created_At { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public DateTime Updated_At { get; set; }
        public List<PostInCategory> PostInCategories { get; set; }
        public List<Comment> Comments { get; set; }
        public List<TagInPost> TagInPosts { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Tên người đăng")]
        public virtual User User { get; set; }

    }
}
