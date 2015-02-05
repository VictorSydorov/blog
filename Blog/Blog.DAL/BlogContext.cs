using System.Data.Entity;
using Blog.Entities;

namespace Blog.DAL
{
    class BlogContext:DbContext
    {
        public BlogContext(string conName):base(conName)
        {
                
        }

        public DbSet<Post> Posts { set; get; }
        public DbSet<Comment> Comments { set; get; }
        public DbSet<User> Users { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new CommentConfig());
            modelBuilder.Configurations.Add(new PostConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
