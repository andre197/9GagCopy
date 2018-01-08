namespace NineGag.Data.Models.Extensions
{
    using Microsoft.EntityFrameworkCore;

    public static class ModelBuilderExtentions
    {
        public static void MapPosts(this ModelBuilder builder)
        {
            builder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId);
        }

        public static void MapComments(this ModelBuilder builder)
        {
            builder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId);

            builder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);

            builder.Entity<Comment>()
                .HasMany(c => c.Replies)
                .WithOne(r => r.Reply)
                .HasForeignKey(r => r.ReplyId);
        }

        public static void MapCommentUpvotes(this ModelBuilder builder)
        {
            builder.Entity<CommentUpvote>()
                 .HasKey(cu => new
                 {
                     cu.UserId,
                     cu.CommentId
                 });

            builder.Entity<CommentUpvote>()
                .HasOne(cu => cu.Comment)
                .WithMany(c => c.CommentUpvotes)
                .HasForeignKey(cu => cu.CommentId);

            builder.Entity<CommentUpvote>()
                .HasOne(cu => cu.User)
                .WithMany(u => u.CommentUpvotes)
                .HasForeignKey(cu => cu.UserId);
        }
        public static void MapPostUpvotes(this ModelBuilder builder)
        {
            builder.Entity<PostUpvote>()
                .HasKey(pu => new
                {
                    pu.UserId,
                    pu.PostId
                });

            builder.Entity<PostUpvote>()
                .HasOne(pu => pu.Post)
                .WithMany(p => p.PostUpvotes)
                .HasForeignKey(pu => pu.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PostUpvote>()
                .HasOne(pu => pu.User)
                .WithMany(u => u.PostUpvotes)
                .HasForeignKey(pu => pu.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
