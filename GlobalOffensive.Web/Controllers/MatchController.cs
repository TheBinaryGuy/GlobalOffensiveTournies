using GlobalOffensive.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GlobalOffensive.Web.Controllers
{
    public class MatchController : Controller
    {
        private readonly HttpClient _client;

        public MatchController(HttpClient client)
        {
            _client = client;
        }

        // GET: Match/Details/5
        [OutputCache(Duration = 60)]
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var response = await _client.GetAsync($"api/match/{id}");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<Match>(result);
                return View(model);
            }
            catch (HttpRequestException ex)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Match/Delete/5
        public async Task<ActionResult> Delete(int id, int? tournamentId = null)
        {
            try
            {
                var response = await _client.DeleteAsync($"api/match/{id}");
                response.EnsureSuccessStatusCode();
                if (tournamentId != null)
                {
                    return RedirectToAction("Details", "Home", new { id = tournamentId });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (HttpRequestException ex)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}