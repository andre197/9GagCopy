namespace NineGag.Logic.Implementations
{
    using Infrastructure.ViewModels;
    using Services;
    using System.Threading.Tasks;

    public class UsersLogic : IUsersLogic
    {
        private IUsersService service;

        public UsersLogic(IUsersService service)
        {
            this.service = service;
        }
        
        public async Task<UserAvatarViewModel> GetUserAvatar(string userId)
        {
            var avatar = new UserAvatarViewModel()
            {
                Avatar = (await this.service.GetUserById(userId)).Avatar
            };

            return avatar;
        }
    }
}
