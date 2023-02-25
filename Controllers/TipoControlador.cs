using ApiRestBambishop.Datos;
using ApiRestBambishop.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestBambishop.Controllers
{
    [ApiController]
    [Route("apibambishop/tipo")]
    public class TipoControlador : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Mtipo>>> Get()
        {
            var funcion = new Dtipo();
            var lista = await funcion.MostrarTipos();
            return lista;
        }

        [HttpGet("tipo:{IdTipo}")]
        public async Task<ActionResult<List<Mtipo>>> GetbyId(int IdTipo)
        {
            var parametros = new Mtipo();
            parametros.IdTipo = IdTipo;
            var funcion = new Dtipo();
            var lista = await funcion.MostrarTipoPorId(parametros);
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] Mtipo parametros)
        {
            var funcion = new Dtipo();
            await funcion.InsertarTipo(parametros);
        }

        [HttpPut("tipo:{IdTipo}")]
        public async Task<ActionResult> Put(int IdTipo, [FromBody] Mtipo parametros)
        {
            var funcion = new Dtipo();
            parametros.IdTipo = IdTipo;
            await funcion.EditarTipo(parametros);
            return NoContent();
        }

        [HttpDelete("tipo:{IdTipo}")]
        public async Task<ActionResult> Delete(int IdTipo)
        {
            var funcion = new Dtipo();
            var parametros = new Mtipo();
            parametros.IdTipo = IdTipo;
            await funcion.EliminarTipo(parametros);
            return NoContent();

        }

    }
}
