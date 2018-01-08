namespace NineGag.Services
{
    using Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task AddComment(Comment comment);

        Task<Comment> GetCommentById(int commentId);

        Task RemoveComment(int commentId);

        IEnumerable<Comment> GetComments();
    }
}
