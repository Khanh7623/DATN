using IndividualBlog.Utilties.Enum;
using System;
using System.Collections.Generic;

namespace IndividualBlog.Models.ViewModel
{
    public class ViewModelPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public EPost Status { get; set; } 
        public int View { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public virtual List<Category> Categories { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Tag> Tag { get; set; }
        public string Author { get; set; }
    }
}
