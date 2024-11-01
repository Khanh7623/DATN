using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IndividualBlog.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Tên danh mục")]
        public string Title { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        public string Slug { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime Created_At { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public DateTime Updated_At { get; set; }
        public List<PostInCategory> PostInCategories { get; set; }
    }
}
