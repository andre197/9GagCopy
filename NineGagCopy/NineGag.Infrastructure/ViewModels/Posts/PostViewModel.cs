namespace NineGag.Infrastructure.ViewModels
{
    using System;

    public class PostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public byte[] Picture { get; set; }

        public string Url { get; set; }

        public DateTime PostedOn { get; set; }

        public string UserId { get; set; }

        public int CommentsCount { get; set; }

        public int PostUpvotesCount { get; set; }
    }
}
