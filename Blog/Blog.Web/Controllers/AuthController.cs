using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Blog.DAL;
using Blog.Entities;
using Blog.Web.Models.Auth;

namespace Blog.Web.Controllers
{
    public class AuthController : Controller
    {
        private IRepository<User> repo = null;
        private string con = "db";

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Post");
        }

        public ActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
                RedirectToAction("index", "Post");
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                using (repo = new Repository<User>(con))
                {
                    var user = repo.FindByProperty(x => x.UserName.Equals(model.Username)).FirstOrDefault();
                    if (user != null)
                    {
                        if (user.Password.Equals(model.Password))
                        {
                            FormsAuthentication.SetAuthCookie(model.Username, true);
                            return RedirectToAction("index", "Post");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Wrong login or password");
                            return View();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Wrong login or password");
                        return View();
                    }
                }
              
            }
            else
                return View();
        }

    }
}
