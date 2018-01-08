namespace NineGag.Logic
{
    using Infrastructure.BindingModels;
    using Infrastructure.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostsLogic
    {
        IEnumerable<DetailedPostViewModel> GetAllPosts(string category = "hot");

        Task<DetailedPostViewModel> GetPostById(int id);

        Task AddPost(PostBindingModel post, string userId);

        Task RemovePost(int postId);

        IEnumerable<PostViewModel> GetPostsByUserId(string userId);

        Task UpvotePost(int postId, string userId);
    }
}
