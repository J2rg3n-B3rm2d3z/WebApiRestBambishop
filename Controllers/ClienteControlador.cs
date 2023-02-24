using Microsoft.AspNetCore.Mvc;
using ApiRestBambishop.Datos;
using ApiRestBambishop.Modelos;

namespace ApiRestBambishop.Controllers
{
    [ApiController]
    [Route("apibambishop/cliente")]
    public class ClienteControlador:ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<MCliente>>> Get()
        {
            var funcion = new Dcliente();
            var lista = await funcion.MostrarClientes();
            return lista;
        }

        [HttpGet("cliente:{IdCliente}")]
        public async Task<ActionResult<List<MCliente>>> GetbyId(int IdCliente)
        {
            var parametros = new MCliente();
            parametros.IdCliente = IdCliente;
            var funcion = new Dcliente();
            var lista = await funcion.MostrarClientePorId(parametros);
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] MCliente parametros)
        {
            var funcion = new Dcliente();
            await funcion.InsertarCliente(parametros);
        }

        [HttpPut("cliente:{IdCliente}")]
        public async Task<ActionResult> Put(int IdCliente, [FromBody] MCliente parametros)
        {
            var funcion = new Dcliente();
            parametros.IdCliente = IdCliente;
            await funcion.EditarCliente(parametros);
            return NoContent();
        }

        [HttpDelete("cliente:{IdCliente}")]
        public async Task<ActionResult> Delete(int IdCliente)
        {
            var funcion = new Dcliente();
            var parametros = new MCliente();
            parametros.IdCliente = IdCliente;
            await funcion.EliminarCliente(parametros);
            return NoContent();

        }
    }
}
