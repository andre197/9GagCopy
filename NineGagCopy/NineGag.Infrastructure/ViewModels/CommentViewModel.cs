namespace NineGag.Infrastructure.ViewModels
{
    using Data.Models;
    using System;
    using System.Collections.Generic;

    public class CommentViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public byte[] Picture { get; set; }

        public string Url { get; set; }

        public DateTime CommentedOn { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int PostId { get; set; }

        public int? ReplyId { get; set; }

        public Comment Reply { get; set; }

        public ICollection<Comment> Replies { get; set; } = new HashSet<Comment>();

        public ICollection<CommentUpvote> CommentUpvotes { get; set; } = new HashSet<CommentUpvote>();
    }
}