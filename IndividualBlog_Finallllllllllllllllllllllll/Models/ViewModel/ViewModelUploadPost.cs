using IndividualBlog.Utilties.Enum;
using System;

namespace IndividualBlog.Models.ViewModel
{
    public class ViewModelUploadPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public EPost Status { get; set; } = EPost.Approved;
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
    }
}
