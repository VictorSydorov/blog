using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Models.Comment
{
    public class CommentCreateModel
    {
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public int? ParentId { get; set; }
        public int PostId { get; set; }
    }
}