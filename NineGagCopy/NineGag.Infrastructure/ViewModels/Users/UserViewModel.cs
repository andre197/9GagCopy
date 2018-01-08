namespace NineGag.Infrastructure.ViewModels.Users
{
    using Data.Models;
    using System.Collections.Generic;

    public class UserViewModel : UserAvatarViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public ICollection<PostViewModel> Posts { get; set; } = new List<PostViewModel>();
    }
}
