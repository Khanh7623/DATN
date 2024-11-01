using System.Collections.Generic;

namespace IndividualBlog.Models
{
    public class PostInCategory
    {
        public virtual Post Post { get; set; }
        public int PostId { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
