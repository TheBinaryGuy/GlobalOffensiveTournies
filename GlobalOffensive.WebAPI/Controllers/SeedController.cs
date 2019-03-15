using GlobalOffensive.WebAPI.Data;
using GlobalOffensive.WebAPI.Models;
using ServiceStack.OrmLite;
using System.Threading.Tasks;
using System.Web.Http;

namespace GlobalOffensive.WebAPI.Controllers
{
    public class SeedController : ApiController
    {
        private readonly AppConnFactory _connFactory;

        public SeedController(AppConnFactory connFactory)
        {
            _connFactory = connFactory;
        }

        // GET api/<controller>
        public async Task<string> Get()
        {
            using (var db = await _connFactory.OpenDbConnectionAsync())
            {
                db.CreateTableIfNotExists<Tournament>();
                db.CreateTableIfNotExists<Match>();
            }
            return "OK";
        }
    }
}