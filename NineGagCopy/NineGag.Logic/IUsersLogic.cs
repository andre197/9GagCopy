namespace NineGag.Logic
{
    using Infrastructure.ViewModels;
    using Infrastructure.ViewModels.Users;
    using System.Threading.Tasks;

    public interface IUsersLogic
    {
        Task<UserAvatarViewModel> GetUserAvatar(string userId);

        Task<UserViewModel> GetUserById(string userId);
    }
}
