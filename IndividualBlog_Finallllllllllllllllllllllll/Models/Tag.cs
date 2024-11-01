using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IndividualBlog.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [Display(Name = "Tên thẻ")]
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<TagInPost> TagInPosts { get; set; }
    }
}
