namespace NineGag.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public byte[] Picture { get; set; }
        
        public string Url { get; set; }

        public DateTime PostedOn { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public ICollection<PostUpvote> PostUpvotes { get; set; } = new HashSet<PostUpvote>();
    }
}