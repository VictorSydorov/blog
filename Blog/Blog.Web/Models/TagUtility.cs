using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Models
{
    public static class TagUtility
    {
        public static List<string> SplitTags(string tags)
        {
            return new List<string>(tags.Split(','));
        }
    }
}