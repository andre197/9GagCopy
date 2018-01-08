namespace NineGag.Services
{
    using Data.Models;
    using System.Threading.Tasks;

    public interface IUsersService
    {
        Task<User> GetUserById(string userId);
    }
}
