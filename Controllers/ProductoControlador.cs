using Microsoft.AspNetCore.Mvc;
using ApiRestBambishop.Datos;
using ApiRestBambishop.Modelos;

namespace ApiRestBambishop.Controllers
{
    [ApiController]
    [Route("apibambishop/producto")]
    public class ProductoControlador:ControllerBase
    {
        [HttpGet]q
        public async Task<ActionResult<List<Mproducto>>> Get()
        {
            var funcion = new Dproducto();
            var lista = await funcion.MostrarProductos();
            return lista;
        }

        [HttpGet("producto:{IdProducto}")]
        public async Task<ActionResult<List<Mproducto>>> GetbyId(int IdProducto)
        {
            var parametros = new Mproducto();
            parametros.IdProducto = IdProducto;
            var funcion = new Dproducto();
            var lista = await funcion.MostrarProductoPorId(parametros);
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] Mproducto parametros)
        {
            var funcion = new Dproducto();
            await funcion.InsertarProducto(parametros);
        }

        [HttpPut("producto:{IdProducto}")]
        public async Task<ActionResult> Put(int IdProducto, [FromBody] Mproducto parametros)
        {
            var funcion = new Dproducto();
            parametros.IdProducto = IdProducto;
            await funcion.EditarProducto(parametros);
            return NoContent();
        }

        [HttpDelete("producto:{IdProducto}")]
        public async Task<ActionResult> Delete(int IdProducto)
        {
            var funcion = new Dproducto();
            var parametros = new Mproducto();
            parametros.IdProducto = IdProducto;
            await funcion.EliminarProducto(parametros);
            return NoContent();

        }
    }
}
