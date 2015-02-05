using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models.PostModels
{
    public class PostCreateModel
    {
        [Required]
        [MaxLength(50)]
        [DataType(DataType.MultilineText)]
        public string Title { get; set; }
        [Required]
        [MaxLength(2000)]
        [DisplayName("Text:")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        [DisplayName("Enter tags separated by commas:")]
        public string Tags { set; get; }
    }
}