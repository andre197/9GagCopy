namespace NineGag.Infrastructure.ViewModels
{
    using System.Collections.Generic;

    public class DetailedPostViewModel : PostViewModel
    {
        public IEnumerable<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();

        public UserAvatarViewModel CurrentUserAvatar { get; set; }
    }
}
