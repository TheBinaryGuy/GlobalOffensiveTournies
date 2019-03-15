using GlobalOffensive.WebAPI.Models;
using GlobalOffensive.WebAPI.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace GlobalOffensive.WebAPI.Controllers
{
    [AllowAnonymous]
    public class TournamentController : ApiController
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        // GET api/<controller>
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Json(await _tournamentService.GetAllTournamentsAsync());
        }

        // GET api/<controller>/5
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            return Json(await _tournamentService.GetTournamentByIdAsync(id));
        }

        // GET api/<controller>/match/5
        [HttpGet]
        [Route("api/tournament/matches/{id}")]
        public async Task<IHttpActionResult> Matches(int id)
        {
            return Json(await _tournamentService.GetMatches(id));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]Tournament tournament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Json(await _tournamentService.AddTournamentAsync(tournament));
        }

        // PATCH api/controller>
        [HttpPatch]
        public async Task<IHttpActionResult> Patch([FromBody] Tournament tournament)
        {
            return Json(await _tournamentService.UpdateTournamentAsync(tournament));
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            return Json(await _tournamentService.DeleteTournamentAsync(id));
        }
    }
}