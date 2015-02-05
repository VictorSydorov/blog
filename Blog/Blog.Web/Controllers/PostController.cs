using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.DAL;
using Blog.Entities;
using  System.Data.Entity ;

using Blog.Web.Models.PostModels;

namespace Blog.Web.Controllers
{
    public class PostController : Controller
    {
        private IRepository<Post> repo=new Repository<Post>("db"); 
      
        public ActionResult Index()
        {
            using (repo)
            {
                
                var res = repo.GetAll(orderBy:x=>x.OrderBy(e=>e.DateCreated),
                    includeProperties:"User,Comments")
                    .Select(x => new PostDisplayModel(x)).ToList();
                return View(res);
            }
            
        }

        public ActionResult Posts(string tag)
        {
            var res = repo.GetAll(orderBy: x => x.OrderBy(e => e.DateCreated),
                filter: x => x.Tags.Contains(tag),includeProperties:"User,Comments")
                .Select(x=>new PostDisplayModel(x)).ToList();
            return View("index", res);
        }

        public ActionResult Post(int id)
        {
            using (repo)
            {
                var res = repo.FindById(id);
                return View(res);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
           if (User.Identity.IsAuthenticated)
                return View();
            else
               return RedirectToAction("Index");
           
        }

        [HttpPost]
        public ActionResult Create(PostCreateModel model)
        {

            if (ModelState.IsValid)
            {
                string name = User.Identity.Name;
                var userRepo = new Repository<User>("db");
                var user =  userRepo.FindByProperty(x=>x.UserName.Equals(name)).First();
                Post post=new Post();
                post.Title = model.Title;
                post.Tags = model.Tags;
                post.Content = model.Content;
                post.DateCreated = DateTime.Now;
                post.DateUpdate = DateTime.Now;
                user.Posts.Add(post);
                userRepo.Update(user);
            }
            return RedirectToAction("Index");
        }

        
    }
}
