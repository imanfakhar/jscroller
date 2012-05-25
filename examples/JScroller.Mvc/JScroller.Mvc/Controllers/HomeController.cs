using System.Linq;
using System.Web.Mvc;
using JScroller.Mvc.Models;

namespace JScroller.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetBrands(int start, int numberOfRowsToRetrieve)
        {
            var total = Repo.GetAll().Count;

            var rows = Repo.GetAll().Skip(start).Take(numberOfRowsToRetrieve).ToList();

            var result = new { success = true, total, data = rows, message = string.Empty };

            return Json(result);
        }
    }
}
