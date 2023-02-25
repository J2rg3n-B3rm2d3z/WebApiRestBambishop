using ApiRestBambishop.Datos;
using ApiRestBambishop.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestBambishop.Controllers
{
    [ApiController]
    [Route("apibambishop/factura")]
    public class FacturaControlador: ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Mfactura>>> Get()
        {
            var funcion = new Dfactura();
            var lista = await funcion.MostrarFacturas();
            return lista;
        }

        [HttpGet("factura:{IdFactura}")]
        public async Task<ActionResult<List<Mfactura>>> GetbyId(int IdFactura)
        {
            var parametros = new Mfactura();
            parametros.IdFactura = IdFactura;
            var funcion = new Dfactura();
            var lista = await funcion.MostrarFacturaPorId(parametros);
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] Mfactura parametros)
        {
            var funcion = new Dfactura();
            await funcion.InsertarFactura(parametros);
        }

        [HttpPut("factura:{IdFactura}")]
        public async Task<ActionResult> Put(int IdFactura, [FromBody] Mfactura parametros)
        {
            var funcion = new Dfactura();
            parametros.IdFactura = IdFactura;
            await funcion.EditarFactura(parametros);
            return NoContent();
        }

        [HttpDelete("factura:{IdFactura}")]
        public async Task<ActionResult> Delete(int IdFactura)
        {
            var funcion = new Dfactura();
            var parametros = new Mfactura();
            parametros.IdFactura = IdFactura;
            await funcion.EliminarFactura(parametros);
            return NoContent();

        }
    }
}
