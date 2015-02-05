using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using Blog.DAL;
using Blog.Entities;

namespace Blog.Web.App_Start
{
    public class SeedDatabase
    {
        private const string con = "db";

        internal static void Seed()
        {
            //user
            using (var repo = new Repository<User>(con))
            {
             
                if (!repo.GetAll(includeProperties:"Posts").Any())
                {
                    User user = new User
                    {
                        UserName = "demo",
                        Password = "demo"
                     
                    };
                   
                    //posts for user
                    ICollection<Post> posts=new List<Post>(3);
                            for (int i = 0; i < 3; i++)
                            {
                                Post post = new Post
                                {
                                    Title = "Test post #" + i,
                                    Tags = "test,demo,other",
                                    Content = @"Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos, qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui dolorem ipsum, quia dolor sit, amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt, ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit, qui in ea voluptate velit esse, quam nihil molestiae consequatur, vel illum, qui dolorem eum fugiat, quo voluptas nulla pariatur? At vero eos et accusamus et iusto odio dignissimos ducimus, qui blanditiis praesentium voluptatum deleniti atque corrupti, quos dolores et quas molestias excepturi sint, obcaecati cupiditate non provident, similique sunt in culpa, qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio, cumque nihil impedit, quo minus id, quod maxime placeat, facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet, ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.",
                                    DateCreated = DateTime.Now,
                                    DateUpdate = DateTime.Now,
                                    User=user
                                };
                                //Comment[] comments=new Comment[3];
                                //for (int j = 0; j < 3; j++)
                                //{
                                //    Comment com=new Comment
                                //    {
                                //        Author = "Anonimous",
                                //        Content = "This is test comment",
                                //        CreateTime = DateTime.Now,
                                        
                                //    };
                                //}

                                posts.Add(post);
                         
                        }
                    user.Posts = posts;
                       repo.Add(user);
                    }
                }
            }

        }
    }
