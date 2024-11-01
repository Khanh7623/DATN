using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IndividualBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Display(Name = "Nội dung")]
        public string Content { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime Created_At { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public DateTime Updated_At { get; set; }
        
        public int PostId { get; set; }
        [Display(Name = "Bài đăng số")]
        public virtual Post Post { get; set; }
        
        public int UserId { get; set; }
        [Display(Name = "Tài khoản số")]
        public virtual User User { get; set; }
      
        public int ParentId { get; set; }
        public virtual Comment Parent { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
