namespace NineGag.Web.Controllers
{
    using Infrastructure.BindingModels;
    using Infrastructure.Extensions;
    using Logic;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using System.Security.Claims;
    using System;
    using Microsoft.AspNetCore.Http;
    using System.IO;

    [Route("posts")]
    public class PostsController : Controller
    {
        private IPostsLogic postsLogic;
        private IUsersLogic usersLogic;

        public PostsController(IPostsLogic postsLogic, IUsersLogic usersLogic)
        {
            this.postsLogic = postsLogic;
            this.usersLogic = usersLogic;
        }

        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var userId = this.User.GetUserId();

            var result = await this.postsLogic.GetPostById(id);

            if (result == null)
            {
                return View("NotFound");
            }

            if (userId != null)
            {
                result.CurrentUserAvatar = await this.usersLogic.GetUserAvatar(userId);
            }

            return View(result);
        }

        [Route("{category?}")]
        [HttpGet]
        public IActionResult GetAllPosts(string category = "hot")
        {
            if (category == "hot"
                || category == "trending"
                || category == "fresh")
            {
                var result = this.postsLogic.GetAllPosts(category);

                return View(result);
            }

            return BadRequest(category);
        }

        [Route("add")]
        [HttpGet]
        [Authorize]
        public IActionResult AddPost()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [Route("add")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPost(PostBindingModel model, IFormFile picture)
        {
            try
            {
                if (!ModelState.IsValid
                || (picture == null && model.Url == null)
                || (picture != null && model.Url != null))
                {
                    return View(model);
                }

                if (!this.User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Login", "Account");
                }

                var userId = this.User.GetUserId();

                if (picture != null)
                {
                    model.Picture = ConvertToBytes(picture);
                }

                await this.postsLogic.AddPost(model, userId);

                return RedirectToAction("GetAllPosts");
            }
            catch (Exception e)
            {
                return View(model);
            }
        }

        [Route("delete")]
        [HttpGet]
        [Authorize]
        public IActionResult DeletePost()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [Route("delete/{id}")]
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePost(int id)
        {
            var currentUserId = this.User.GetUserId();
            var postCreatorId = (await this.postsLogic.GetPostById(id)).UserId;

            if (currentUserId != postCreatorId)
            {
                return Unauthorized();
            }

            try
            {
                await this.postsLogic.RemovePost(id);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            return RedirectToAction("GetAllPosts");
        }

        [Route("upvote/{n:int}")]
        [HttpGet]
        [Authorize]
        public IActionResult UpvotePost(int n, int postId)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("/account/login");
            }

            if (n > 0)
            {
                this.postsLogic.UpvotePost(postId, this.User.GetUserId());
            }


            return RedirectToAction($"/posts/fresh#{postId}");
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