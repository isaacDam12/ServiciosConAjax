using Microsoft.AspNetCore.Mvc;

namespace CrudServicesAjax.Controllers
{
    public class PedidoController : Controller
    {
        public ActionResult GetAll()
        {
            return View();
        }
    }
}
