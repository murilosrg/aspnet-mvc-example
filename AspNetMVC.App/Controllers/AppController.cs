using System.Web.Mvc;

namespace AspNetMVC.App.Controllers
{
    public class AppController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            return View("~/Views/BoasVindas.cshtml");
        }

        [HttpGet]
        public ActionResult AppView()
        {
            return View((string)RouteData.Values["view"]);
        }

        [HttpGet]
        public ActionResult AppResource()
        {
            return File(string.Format("~/{0}", RouteData.Values["resource"]), "application/octet-stream");
        }
    }
}
