namespace NineGag.Web.Controllers
{
    using Infrastructure.Extensions;
    using Logic;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("users")]
    public class UsersController : Controller
    {
        private IUsersLogic logic;

        public UsersController(IUsersLogic logic)
        {
            this.logic = logic;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await this.logic.GetUserById(id);

            return View(user);
        }
    }
}