using GlobalOffensive.WebAPI.Models;
using GlobalOffensive.WebAPI.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace GlobalOffensive.WebAPI.Controllers
{
    [AllowAnonymous]
    public class MatchController : ApiController
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        // GET api/<controller>
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Json(await _matchService.GetAllMatchesAsync());
        }

        // GET api/<controller>/5
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Json(await _matchService.GetMatchByIdAsync(id));
        }

        // GET api/<controller>/tournament/5
        [HttpGet]
        [Route("api/match/tournament/{id}")]
        public async Task<IHttpActionResult> Tournament(int id)
        {
            return Json(await _matchService.GetTournamentInfo(id));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]Match match)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Json(await _matchService.AddMatchAsync(match));
        }

        // PATCH api/controller>
        [HttpPatch]
        public async Task<IHttpActionResult> Patch([FromBody] Match match)
        {
            return Json(await _matchService.UpdateMatchAsync(match));
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            return Json(await _matchService.DeleteMatchAsync(id));
        }
    }
}