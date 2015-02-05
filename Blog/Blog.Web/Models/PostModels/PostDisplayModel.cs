using System;

namespace Blog.Web.Models.PostModels
{
    public class PostDisplayModel
    {
        public int Id{ get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { set; get; }
        //public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public string User { set; get; }
        public int NumberOfComments { set; get; }

        public PostDisplayModel(Blog.Entities.Post post, int numberOfLetters=200)
        {
            if (post.Content.Length > numberOfLetters)
                this.Content = post.Content.Substring(0, 200);
            this.Tags = post.Tags;
            this.Id = post.Id;
            this.DateCreated = post.DateCreated;
            this.DateUpdate = post.DateUpdate;
            this.Title = post.Title;
            this.User = post.User.UserName;
            this.NumberOfComments = post.Comments != null ? post.Comments.Count : -1;
        }
    }
}