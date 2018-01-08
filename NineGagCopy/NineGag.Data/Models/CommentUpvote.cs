namespace NineGag.Data.Models
{
    public class CommentUpvote
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int CommentId { get; set; }

        public Comment Comment { get; set; }
    }
}
