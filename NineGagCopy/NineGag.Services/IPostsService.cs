namespace NineGag.Services
{
    using Data.Models;
    using Infrastructure.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostsService
    {
        IEnumerable<DetailedPostViewModel> ListPosts(string category = "hot");

        Task<Post> GetById(int id);

        Task AddPost(Post post);

        Task RemovePost(int postId);
    }
}
