using ApiRestBambishop.Datos;
using ApiRestBambishop.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestBambishop.Controllers
{
    [ApiController]
    [Route("apibambishop/proveedor")]
    public class ProveedorControlador : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Mproveedor>>> Get()
        {
            var funcion = new Dproveedor();
            var lista = await funcion.MostrarProveedores();
            return lista;
        }

        [HttpGet("proveedor:{IdProveedor}")]
        public async Task<ActionResult<List<Mproveedor>>> GetbyId(int IdProveedor)
        {
            var parametros = new Mproveedor();
            parametros.IdProveedor = IdProveedor;
            var funcion = new Dproveedor();
            var lista = await funcion.MostrarProveedorPorId(parametros);
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] Mproveedor parametros)
        {
            var funcion = new Dproveedor();
            await funcion.InsertarProveedor(parametros);
        }

        [HttpPut("proveedor:{IdProveedor}")]
        public async Task<ActionResult> Put(int IdProveedor, [FromBody] Mproveedor parametros)
        {
            var funcion = new Dproveedor();
            parametros.IdProveedor = IdProveedor;
            await funcion.EditarProveedor(parametros);
            return NoContent();
        }

        [HttpDelete("proveedor:{IdProveedor}")]
        public async Task<ActionResult> Delete(int IdProveedor)
        {
            var funcion = new Dproveedor();
            var parametros = new Mproveedor();
            parametros.IdProveedor = IdProveedor;
            await funcion.EliminarProveedor(parametros);
            return NoContent();

        }
    }
}
