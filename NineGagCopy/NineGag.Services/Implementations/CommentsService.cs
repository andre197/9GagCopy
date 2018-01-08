namespace NineGag.Services.Implementations
{
    using Data;
    using Data.Models;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;

    public class CommentsService : ICommentsService
    {
        private NineGagDbContext db;

        public CommentsService(NineGagDbContext db)
        {
            this.db = db;
        }

        public async Task AddComment(Comment comment)
        {
            this.db.Comments.Add(comment);
            await this.db.SaveChangesAsync();
        }

        public async Task<Comment> GetCommentById(int commentId)
        {
            var comment = await this.db.Comments.FindAsync(commentId);

            return comment;
        }

        public IEnumerable<Comment> GetComments()
        {
            var result = this.db.Comments.ToList();

            return result;
        }

        public async Task RemoveComment(int commentId)
        {
            var comment = await GetCommentById(commentId);

            this.db.Remove(comment);
            await this.db.SaveChangesAsync();
        }
    }
}
