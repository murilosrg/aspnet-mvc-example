using System.Web.Mvc;

namespace AspNetMVC.App.Controllers
{
    public class ErrosController : Controller
    {
        [HttpGet]
        [Route("PaginaNaoEncontrada")]
        public ActionResult PaginaNaoEncontrada()
        {
            Response.StatusCode = 404;
            return View("~/Views/Erros/PaginaNaoEncontrada.cshtml");
        }

        [HttpGet]
        [Route("RequisicaoNaoCompletada")]
        public ActionResult RequisicaoNaoCompletada()
        {
            Response.StatusCode = 500;
            return View("~/Views/Erros/RequisicaoNaoCompletada.cshtml");
        }
    }
}