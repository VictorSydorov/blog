using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities
{
   public class Comment: BaseEntity
    {
       // public int Id{ get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public int? ParentId { get; set; }
        public Comment Parent { set; get; }
       //public string Url { get; set; }
        public int PostId { get; set; }

        public virtual ICollection<Comment> Children { get; set; } 
    }

    public class CommentConfig : EntityTypeConfiguration<Comment>
    {
        public CommentConfig()
        {
            Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(1000);

            Property(x => x.CreateTime)
                .IsRequired();
               // .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            Property(x => x.Email)
                .IsOptional()
                .HasMaxLength(50);

            HasOptional(x => x.Parent)
                .WithMany(x=>x.Children)
                .HasForeignKey(x=>x.ParentId)
                .WillCascadeOnDelete(false);

            Property(x => x.PostId).IsRequired();

        }
    }
}
