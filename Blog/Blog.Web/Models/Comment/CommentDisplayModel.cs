using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Entities;
namespace Blog.Web.Models.Comment
{
    public class CommentDisplayModel
    {
        public int Id { set; get; }
        public string Content { get; set; }
        public string CreateTime { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public int? ParentId { get; set; }
        public List<CommentDisplayModel> Children { set; get; }
    

        public CommentDisplayModel(Blog.Entities.Comment com)
        {
            Id = com.Id;
            Content = com.Content;
            CreateTime = com.CreateTime.ToLongDateString();
            Author = com.Author ?? "Anomynous";
            Email = com.Email;
            ParentId = com.ParentId;
            Children=new List<CommentDisplayModel>();
        }

    }

    public sealed class CommentDisplayModelTree
    {
        private List<CommentDisplayModel> comments = null;
        private bool treeBuilt = false;

        public CommentDisplayModelTree(List<CommentDisplayModel> comments)
        {
           Comments = comments;
        }

        public List<CommentDisplayModel> Comments
        {
           private set { comments = value; }

            get
            {
                if (!treeBuilt)
                {
                    BuildTree();
                    treeBuilt = true;
                }
                return comments;
            }
        }

        private void BuildTree()
        {
            if (comments == null || comments.Count == 0)
                return;
            comments.ForEach(
                x => comments.ForEach(y =>
                {
                    if(y.ParentId==x.Id)
                        x.Children.Add(y);
                }));
            comments = comments.Where(x => x.ParentId == null).ToList();
        }

    }
}