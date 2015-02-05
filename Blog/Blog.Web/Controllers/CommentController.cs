using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.DAL;
using Blog.Entities;
using Blog.Web.Models.Comment;

namespace Blog.Web.Controllers
{
    public class CommentController : Controller
    {
        private IRepository<Comment> repo=new Repository<Comment>("db");

        [HttpGet]
       
        public ActionResult Index(int post)
        {
            using (repo)
            {
                var res = new CommentDisplayModelTree(repo.GetAll(filter: x => x.PostId == post).
                    Select(x=>new CommentDisplayModel(x)).ToList());
                return Json(res.Comments, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Create(int postId,int parent=-1)
        {
            if (parent != -1)
                ViewBag.Comment = repo.FindById(parent);
            ViewBag.PostId = postId;
            return View();
        }

        [HttpPost]
        public ActionResult Create(CommentCreateModel model)
        {
            if (ModelState.IsValid)
            {
                Comment com = new Comment
                {
                    CreateTime = DateTime.Now,
                    Email = model.Email,
                    Author = model.Author,
                    PostId = model.PostId,
                    ParentId = model.ParentId,
                    Content = model.Content
                };

                repo.Add(com);
                return RedirectToAction("post","post",new{id=model.PostId});
            }
           
            return View();
        }
    }
}
