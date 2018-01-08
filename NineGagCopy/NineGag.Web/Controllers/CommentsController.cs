namespace NineGag.Web.Controllers
{
    using Infrastructure.BindingModels;
    using Infrastructure.Extensions;
    using NineGag.Logic;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;
    using System.Threading.Tasks;
    using NineGag.Infrastructure.ViewModels;

    [Route("comments")]
    public class CommentsController : Controller
    {
        private ICommentsLogic logic;

        public CommentsController(ICommentsLogic logic)
        {
            this.logic = logic;
        }

        [Route("add")]
        [HttpGet]
        [Authorize]
        public IActionResult AddComment(int postId)
        {
            ViewData["PostId"] = postId;

            return View();
        }

        [Route("add")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment(CommentBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                model.UserId = this.User.GetUserId();

                await this.logic.AddComment(model);

                return RedirectToAction(model.PostId.ToString(), "Posts", "comments");
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [Route("/remove/{commentId:int}")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> RemoveComment(int commentId)
        {
            var post = await this.logic.GetCommentById(commentId);

            return View(post);
        }

        [Route("/remove/{commentId:int}")]
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> RemoveComment(CommentViewModel viewComment)
        {
            var comment = await this.logic.GetCommentById(viewComment.Id);

            if (comment == null)
            {
                return RedirectToAction("GetAllPosts", "Posts");
            }

            var currentUserId = this.User.GetUserId();
            var commentCreatorId = comment.UserId;

            if (commentCreatorId != currentUserId)
            {
                return Unauthorized();
            }

            try
            {
                await this.logic.RemoveComment(comment.Id);

                return RedirectToAction(comment.PostId.ToString(), "Posts", "comments");
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        private byte[] ConvertToBytes(IFormFile image)
        {
            byte[] CoverImageBytes = null;
            BinaryReader reader = new BinaryReader(image.OpenReadStream());
            CoverImageBytes = reader.ReadBytes((int)image.Length);
            return CoverImageBytes;
        }
    }
}