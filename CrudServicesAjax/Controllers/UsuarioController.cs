using Microsoft.AspNetCore.Mvc;

namespace CrudServicesAjax.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult GetAll()
        {
            return View();
        }

        
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(int idUsuario)
        {
            return View();
        }
    }
}
