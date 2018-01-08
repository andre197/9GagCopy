namespace NineGag.Data
{
    using NineGag.Data.Models.Extensions;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class NineGagDbContext : IdentityDbContext<User>
    {
        public NineGagDbContext(DbContextOptions<NineGagDbContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostUpvote> PostUpvotes { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CommentUpvote> CommentUpvotes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var user = new User();

            builder.MapPosts();
            builder.MapComments();
            builder.MapCommentUpvotes();
            builder.MapPostUpvotes();
        }
    }
}
