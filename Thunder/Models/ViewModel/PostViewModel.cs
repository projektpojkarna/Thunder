using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thunder.Models.ViewModel
{
    public class PostViewModel
    {
        public static PostViewModel FromPostAndAuthor(Post post, string authorName)
        {
            return new PostViewModel()
            {
                Author_FullName = authorName,
                Author_UserId = post.Author_UserId,
                Text = post.Text
            };
        }

        public string UserId { get; set; }
        public string Author_UserId { get; set; }
        public string Author_FullName { get; set; }
        public string Text { get; set; }
    }
}