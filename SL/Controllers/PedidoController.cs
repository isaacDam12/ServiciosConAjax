using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        [HttpPost("Add")]

        public IActionResult Add([FromBody] ML.Pedido pedido)
        {
            Dictionary<string, object> result = BL.Pedido.Add(pedido);
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
            Dictionary<string,object>result = BL.Pedido.GetAll();
            bool rs = (bool)result["Resultado"];

            if (rs)
            {
                ML.Pedido pedido = (ML.Pedido)result["Pedido"];
                return Ok(result);
            }
            else
            {
                string msg = (string)result["Mensaje"];
                return BadRequest();
            }
        }

        [HttpGet("GetById/{idPedido}")]
        public IActionResult GetById(int idPedido)
        {
            Dictionary<string, object> result = BL.Pedido.GetById(idPedido);
            bool rs = (bool)result["Resultado"];

            if (rs)
            {
                ML.Pedido pedido = (ML.Pedido)result["Pedido"];
                return Ok(result);
            }
            else
            {
                string msg = (string)result["Mensaje"];
                return BadRequest();
            }
        }

        [HttpDelete("Delete/{idPedido}")]
        public IActionResult Delete(int idPedido)

        {
            Dictionary<string,object>result = BL.Pedido.Delete(idPedido);

            bool rs = (bool)result["Resultado"];
            if(rs)
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
        public IActionResult Update([FromBody]ML.Pedido pedido)
        {
            Dictionary<string,object>result = BL.Pedido.Update(pedido);
            bool rs = (bool)result["Resultado"];
            if(rs)
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
