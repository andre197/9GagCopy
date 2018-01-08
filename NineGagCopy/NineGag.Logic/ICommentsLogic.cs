namespace NineGag.Logic
{
    using Infrastructure.BindingModels;
    using Infrastructure.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICommentsLogic
    {
        Task AddComment(CommentBindingModel model);

        Task<CommentViewModel> GetCommentById(int commentId);

        Task RemoveComment(int commentId);

        IEnumerable<CommentViewModel> GetCommentsByPostId(int postId);
    }
}
