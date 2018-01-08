namespace NineGag.Logic.Implementations
{
    using AutoMapper;
    using Infrastructure.ViewModels;
    using Infrastructure.ViewModels.Users;
    using NineGag.Data.Models;
    using Services;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsersLogic : IUsersLogic
    {
        private IUsersService service;
        private IPostsLogic postsLogic;

        public UsersLogic(IUsersService service, IPostsLogic postsLogic)
        {
            this.service = service;
            this.postsLogic = postsLogic;
        }
        
        public async Task<UserAvatarViewModel> GetUserAvatar(string userId)
        {
            var avatar = new UserAvatarViewModel()
            {
                Avatar = (await this.service.GetUserById(userId)).Avatar
            };

            return avatar;
        }

        public async Task<UserViewModel> GetUserById(string userId)
        {
            var user = await this.service.GetUserById(userId);

            if (user != null)
            {
                var mappedUser = Mapper.Map<User, UserViewModel>(user);

                var usersPosts = this.postsLogic.GetPostsByUserId(userId).ToList();

                mappedUser.Posts = usersPosts;

                return mappedUser;
            }

            return null;
        }
    }
}
