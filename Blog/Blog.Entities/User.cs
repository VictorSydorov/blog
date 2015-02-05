using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entities
{
   public class User:BaseEntity
    {
        //public int Id{ get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public string Salt { get; set; }
        //public string Email { get; set; }
        //public string Profile { get; set; }

        public virtual ICollection<Post> Posts { get; set; } 
    }

    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            Property(x => x.UserName).IsRequired().HasMaxLength(30);
            Property(x => x.Password).IsRequired().HasMaxLength(20);
            HasMany(x => x.Posts).WithRequired(x => x.User);
        }
    }
}
