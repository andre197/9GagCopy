namespace NineGag.Logic.Implementations
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.BindingModels;
    using Infrastructure.ViewModels;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PostsLogic : IPostsLogic
    {
        private IPostsService postsService;
        private IUsersLogic usersLogic;

        public PostsLogic(IPostsService postsService, IUsersLogic usersLogic)
        {
            this.postsService = postsService;
            this.usersLogic = usersLogic;
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

            return mappedResult;
        }

        public async Task RemovePost(int postId)
        {
            await this.postsService.RemovePost(postId);
        }
    }
}
