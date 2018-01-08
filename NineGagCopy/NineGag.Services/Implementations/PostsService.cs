namespace NineGag.Services.Implementations
{
    using AutoMapper;
    using Data;
    using Data.Models;
    using Infrastructure.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PostsService : IPostsService
    {
        private const int Hot = 5000;
        private const int Fresh = 100;

        private NineGagDbContext db;

        public PostsService(NineGagDbContext db)
        {
            this.db = db;
        }

        public async Task AddPost(Post post)
        {
            this.db.Posts.Add(post);
            await this.db.SaveChangesAsync();
        }

        public async Task RemovePost(int postId)
        {
            var post = await GetById(postId);
            this.db.Remove(post);
            await this.db.SaveChangesAsync();
        }

        public IEnumerable<Post> GetAllPostsByUserId(string userId)
        {
            var result = this.db.Posts
                .Where(p => p.UserId == userId)
                .Select(p => p)
                .ToList();

            return result;
        }

        public async Task<Post> GetById(int id)
        {
                var result = await this.db.Posts.FindAsync(id);

                return result;
        }

        public IEnumerable<DetailedPostViewModel> ListPosts(string category = "hot")
        {
                var result = this.db.Posts
                    .Select(p => Mapper.Map<Post, DetailedPostViewModel>(p))
                    .ToList()
                    .Where(p => GetPostsByCategory(p.PostUpvotesCount, category.ToLower()))
                    .Select(p => p)
                    .OrderByDescending(p => p.PostedOn)
                    .Take(100)
                    .ToList();

                return result;
        }

        private bool GetPostsByCategory(int count, string category)
        {
            if (category == "hot")
            {
                return count > Hot;
            }

            if (category == "fresh")
            {
                return count < Fresh;
            }

            return count > Fresh && count < Hot;
        }

        public async Task UpdatePost(Post post)
        {
            this.db.Update(post);
            await this.db.SaveChangesAsync();
        }
    }
}
