namespace NineGag.Logic.Implementations
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.BindingModels;
    using Infrastructure.ViewModels;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CommentsLogic : ICommentsLogic
    {
        private ICommentsService service;

        public CommentsLogic(ICommentsService service)
        {
            this.service = service;
        }

        public async Task AddComment(CommentBindingModel model)
        {
            var comment = Mapper.Map<CommentBindingModel, Comment>(model);

            comment.CommentedOn = DateTime.Now;

            await this.service.AddComment(comment);
        }

        public async Task<CommentViewModel> GetCommentById(int commentId)
        {
            var comment = await this.service.GetCommentById(commentId);

            var mappedComment = Mapper.Map<Comment, CommentViewModel>(comment);

            return mappedComment;
        }

        public async Task RemoveComment(int commentId)
        {
            await this.service.RemoveComment(commentId);
        }

        public IEnumerable<CommentViewModel> GetCommentsByPostId(int postId)
        {
            var comments = this.service.GetComments();

            var commentsByPostId = comments
                .Where(c => c.PostId == postId)
                .Select(c => Mapper.Map<Comment, CommentViewModel>(c));

            return commentsByPostId;
        }
    }
}
