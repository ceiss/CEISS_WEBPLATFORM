using System;
using System.ComponentModel.DataAnnotations;

namespace Classes
{
    public class Article
    {
        [Key]
        public int ArticleID { get; set; }
        [StringLength(140)]
        public string Title { get; set; }
        public string Preview { get; set; }
        public string HTMLContent { get; set; }
        public DateTime PublishDate { get; set; }
        public User Author { get; set; }
        public string PrimaryImage { get; set; }
    }
}
