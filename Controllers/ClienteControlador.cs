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
        public async Task<ActionResult<List<Mcliente>>> Get()
        {
            var funcion = new Dcliente();
            var lista = await funcion.Mostrarclientes();
            return lista;
        }

        [HttpGet("{IdCliente}")]
        public async Task<ActionResult<List<Mcliente>>> GetbyId(int IdCliente)
        {
            var parametros = new Mcliente();
            parametros.IdCliente = IdCliente;
            var funcion = new Dcliente();
            var lista = await funcion.MostrarClientePorId(parametros);
            return lista;
        }
    }
}
