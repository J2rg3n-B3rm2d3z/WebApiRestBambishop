using ApiRestBambishop.Datos;
using ApiRestBambishop.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestBambishop.Controllers
{
    [ApiController]
    [Route("apibambishop/detallefactura")]
    public class DetalleFacturaControlador : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Mdetallefactura>>> Get()
        {
            var funcion = new Ddetallefactura();
            var lista = await funcion.MostrarDetalleFacturas();
            return lista;
        }

        [HttpGet("factura:{IdFactura}")]
        public async Task<ActionResult<List<Mdetallefactura>>> GetbyIdFactura(int IdFactura)
        {
            var parametros = new Mdetallefactura();
            parametros.IdFactura = IdFactura;
            var funcion = new Ddetallefactura();
            var lista = await funcion.MostrarDetalleFacturasPorIdFactura(parametros);
            return lista;
        }

        [HttpGet("producto:{IdProducto}")]
        public async Task<ActionResult<List<Mdetallefactura>>> GetbyIdProducto(int IdProducto)
        {
            var parametros = new Mdetallefactura();
            parametros.IdProducto = IdProducto;
            var funcion = new Ddetallefactura();
            var lista = await funcion.MostrarDetalleFacturasPorIdProducto(parametros);
            return lista;
        }

        [HttpGet("factura:{IdFactura}/producto:{IdProducto}")]
        public async Task<ActionResult<List<Mdetallefactura>>> GetbyBothId(int IdFactura, int IdProducto)
        {
            var parametros = new Mdetallefactura();
            parametros.IdFactura = IdFactura;
            parametros.IdProducto = IdProducto;
            var funcion = new Ddetallefactura();
            var lista = await funcion.MostrarDetalleFacturasPorAmbosId(parametros);
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] Mdetallefactura parametros)
        {
            var funcion = new Ddetallefactura();
            await funcion.InsertarDetalleFactura(parametros);
        }

        [HttpPut("factura:{IdFactura}/producto:{IdProducto}")]
        public async Task<ActionResult> Put(int IdFactura, int IdProducto, [FromBody] Mdetallefactura parametros)
        {
            var funcion = new Ddetallefactura();
            parametros.IdProducto = IdProducto;
            parametros.IdFactura = IdFactura;
            await funcion.EditarDetalleFactura(parametros);
            return NoContent();
        }

        [HttpDelete("factura:{IdFactura}")]
        public async Task<ActionResult> DeletebyIdFactura(int IdFactura)
        {
            var funcion = new Ddetallefactura();
            var parametros = new Mdetallefactura();
            parametros.IdFactura = IdFactura;
            await funcion.EliminarDetalleFacturaPorIdFactura(parametros);
            return NoContent();
        }

        [HttpDelete("producto:{IdProducto}")]
        public async Task<ActionResult> DeletebyIdProducto(int IdProducto)
        {
            var funcion = new Ddetallefactura();
            var parametros = new Mdetallefactura();
            parametros.IdProducto = IdProducto;
            await funcion.EliminarDetalleFacturaPorIdProducto(parametros);
            return NoContent();

        }

        [HttpDelete("factura:{IdFactura}/producto:{IdProducto}")]
        public async Task<ActionResult> Delete(int IdFactura, int IdProducto)
        {
            var funcion = new Ddetallefactura();
            var parametros = new Mdetallefactura();
            parametros.IdProducto = IdProducto;
            parametros.IdFactura = IdFactura;
            await funcion.eliminarDetalleFacturaPorAmbosIds(parametros);
            return NoContent();

        }
    }
}
