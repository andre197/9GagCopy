namespace NineGag.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public byte[] Avatar { get; set; }

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();

        public ICollection<PostUpvote> PostUpvotes { get; set; } = new HashSet<PostUpvote>();

        public ICollection<CommentUpvote> CommentUpvotes { get; set; } = new HashSet<CommentUpvote>();
    }
}
