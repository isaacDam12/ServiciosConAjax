using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost("Add")]

        public IActionResult Add([FromBody] ML.Usuario usuario)
        {
            Dictionary<string, object> result = BL.Usuario.Add(usuario);
            bool rs = (bool)result["Resultado"];
            if (rs)
            {
                return Ok(result);
            }
            else
            {
                string msg = (string)result["Mensaje"];
                return BadRequest(msg);
            }
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
           Dictionary<string,object>result = BL.Usuario.GetAll();
            bool rs = (bool)result["Resultado"];

            if (rs)
            {
                ML.Usuario usuario = (ML.Usuario)result["Usuario"];
                return Ok(usuario);
            }
            else
            {
                string meg = (string)result["Mensaje"];
                return BadRequest(meg);
            }
        }

        [HttpGet("GetById/{idUsuario}")]
        public IActionResult GetById(int idUsuario)
        {
            Dictionary<string, object> result = BL.Usuario.GetById(idUsuario);
            bool rs = (bool)result["Resultado"];

            if (rs)
            {
                ML.Usuario usuario = (ML.Usuario)result["Usuario"];
                return Ok(usuario);
            }
            else
            {
                string meg = (string)result["Mensaje"];
                return BadRequest(meg);
            }
        }

        [HttpDelete("Delete/{idUsuario}")]
        public IActionResult Delete(int idUsuario)
        {
            Dictionary<string,object>result = BL.Usuario.Delete(idUsuario);
            bool rs = (bool)result["Resultado"];

            if (rs)
            {
                return Ok(result);
            }
            else
            {
                string msg = (string)result["Mensaje"];
                return BadRequest(msg);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody]ML.Usuario usuario)
        {
            Dictionary<string,object>result = BL.Usuario.Update(usuario);
            bool rs = (bool)result["Resultado"];
            if (rs)
            {
                return Ok(result);
            }
            else
            {
                string msg = (string)result["Mensaje"];
                return BadRequest(msg);
            }
        }

    }
}
