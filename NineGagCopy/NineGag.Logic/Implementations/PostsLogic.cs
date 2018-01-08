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

    public class PostsLogic : IPostsLogic
    {
        private IPostsService postsService;
        private ICommentsLogic commentsLogic;

        public PostsLogic(IPostsService postsService, ICommentsLogic commentsLogic)
        {
            this.postsService = postsService;
            this.commentsLogic = commentsLogic;
        }

        public async Task AddPost(PostBindingModel post, string userId)
        {
            var mappedPost = Mapper.Map<PostBindingModel, Post>(post);

            mappedPost.PostedOn = DateTime.Now;
            mappedPost.UserId = userId;

            await this.postsService.AddPost(mappedPost);
        }

        public IEnumerable<DetailedPostViewModel> GetAllPosts(string category = "hot")
            => this.postsService.ListPosts(category);

        public async Task<DetailedPostViewModel> GetPostById(int id)
        {
            var result = await this.postsService.GetById(id);

            if (result == null)
            {
                return null;
            }

            var mappedResult = Mapper.Map<Post, DetailedPostViewModel>(result);

            mappedResult.Comments = this.commentsLogic.GetCommentsByPostId(mappedResult.Id);

            return mappedResult;
        }

        public async Task RemovePost(int postId)
        {
            await this.postsService.RemovePost(postId);
        }

        public IEnumerable<PostViewModel> GetPostsByUserId(string userId)
        {
            var posts = this.postsService.GetAllPostsByUserId(userId).Select(p => Mapper.Map<Post, PostViewModel>(p));

            return posts;
        }

        public async Task UpvotePost(int postId, string userId)
        {
            var post = await this.postsService.GetById(postId);

            post.PostUpvotes.Add(new PostUpvote() { UserId = userId, UpvotedOn = DateTime.Now });
            await this.postsService.UpdatePost(post);
        }
    }
}
