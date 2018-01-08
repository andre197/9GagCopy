namespace NineGag.Services.Implementations
{
    using Data;
    using Data.Models;
    using System.Threading.Tasks;

    public class UsersService : IUsersService
    {
        private NineGagDbContext db;

        public UsersService(NineGagDbContext db)
        {
            this.db = db;
        }

        public async Task<User> GetUserById(string userId)
        {
            var user = await this.db.Users.FindAsync(userId);

            return user;
        }
    }
}
