using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using GlobalOffensive.Models;
using System.Net;

namespace GlobalOffensive.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;

        public HomeController(HttpClient client)
        {
            _client = client;
        }

        // GET: Home
        [OutputCache(Duration = 60)]
        public async Task<ActionResult> Index()
        {
            try
            {
                var response = await _client.GetAsync("api/tournament");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<Tournament[]>(result);
                return View(model);
            }
            catch (HttpRequestException ex)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Home/Details/5
        [OutputCache(Duration = 60)]
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var response = await _client.GetAsync($"api/tournament/{id}");
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<Tournament>(result);
                return View(model);
            }
            catch (HttpRequestException ex)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Home/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _client.DeleteAsync($"api/tournament/{id}");
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch (HttpRequestException ex)
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}