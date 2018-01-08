namespace NineGag.Data.Models
{
    using System;

    public class PostUpvote
    {
        public DateTime UpvotedOn { get; set; } = DateTime.Now;

        public string UserId { get; set; }

        public User User { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
