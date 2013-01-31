using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebFront.Controllers
{
    public class LogViewerController : Controller
    {
        //
        // GET: /LogViewer/

        public async Task<ActionResult> Index()
        {
            var entries = await TableStorageLogger.Logger.Get(10, new[] {"Worker", "WebFront"});
            return View(entries.OrderByDescending(e=> e.Created));
        }
    }
}
