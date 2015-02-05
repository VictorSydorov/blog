using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Web.Models.Auth
{
    public class UserModel
    {
        [Required]
        [DisplayName("Login:")]
        public string Username { set; get; }
        [Required]
        [DisplayName("Password:")]
        [DataType(DataType.Password)]
        public string Password { set; get; }
    }
}