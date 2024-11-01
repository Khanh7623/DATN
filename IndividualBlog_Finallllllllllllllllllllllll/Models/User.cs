using IndividualBlog.Utilties.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndividualBlog.Models
{
    public class User
    {
        
      
        public int Id { get; set; }
        [Display(Name = "Tên")]
        public string FirtName { get; set; }
        [Display(Name = "Họ")]
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get => FirtName +" "+LastName; set => FullName= value; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Display(Name = "Ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Chọn hình")]
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Adress { get; set; }
        [Display(Name = "Ghi chú")]
        public string Intro { get; set; }
        [Display(Name = "Trạng thái")]
        public EUserStatus Status { get; set; } = EUserStatus.Active;
        [Display(Name = "Quyền hạn")]
        public EUserRole Role { get; set; } = EUserRole.Member;
        [Display(Name = "Ngày tham gia")]
        public DateTime Created_At { get; set; } = DateTime.Now;
        [Display(Name = "Ngày cập nhật")]
        public DateTime Updated_At { get; set; } = DateTime.Now;
        public List<Comment> Comments { get; set; }
        public List<Post> Posts { get; set; }
    }
}
