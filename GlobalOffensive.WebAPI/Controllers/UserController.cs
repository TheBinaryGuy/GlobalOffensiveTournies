using System.Web.Http;

namespace GlobalOffensive.WebAPI.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(new { Username = User.Identity.Name });
        }
    }
}