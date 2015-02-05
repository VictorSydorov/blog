using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace Blog.Entities
{
    public class Post:BaseEntity
    {
        //public int Id{ get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { set; get; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        public User User { set; get; }

        public virtual ICollection<Comment> Comments { set; get; }
    }

    public class PostConfig : EntityTypeConfiguration<Post>
    {
        public PostConfig()
        {
            Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Content).IsOptional();

            Property(x => x.DateUpdate).IsOptional();

            Property(x => x.Tags).IsRequired();

            Property(x => x.DateCreated)
                .IsRequired();
                //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            HasRequired(x => x.User).WithMany(x => x.Posts);

           
        }
    }
}
