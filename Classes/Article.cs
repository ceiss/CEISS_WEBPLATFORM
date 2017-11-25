using System;
using System.ComponentModel.DataAnnotations;

namespace Classes
{
    public class Article
    {
        [Key]
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string HTMLContent { get; set; }
        public DateTime PublishDate { get; set; }
        public User Author { get; set; }
        public string PrimaryImage { get; set; }
    }
}
