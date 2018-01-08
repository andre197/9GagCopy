namespace NineGag.Logic
{
    using Infrastructure.ViewModels;
    using System.Threading.Tasks;

    public interface IUsersLogic
    {
        Task<UserAvatarViewModel> GetUserAvatar(string userId);
    }
}
