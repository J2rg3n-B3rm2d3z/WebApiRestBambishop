using ApiRestBambishop.Datos;
using ApiRestBambishop.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestBambishop.Controllers
{
    [ApiController]
    [Route("apibambishop/proveedor_producto")]
    public class Proveedor_ProductoControlador: ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Mproveedor_producto>>> Get()
        {
            var funcion = new Dproveedor_Producto();
            var lista = await funcion.MostrarProveedor_Producto();
            return lista;
        }

        [HttpGet("proveedor:{IdProveedor}")]
        public async Task<ActionResult<List<Mproveedor_producto>>> GetbyIdProveedor(int IdProveedor)
        {
            var parametros = new Mproveedor_producto();
            parametros.IdProveedor = IdProveedor;
            var funcion = new Dproveedor_Producto();
            var lista = await funcion.MostrarMostrarProveedor_ProductoPorIdProveedor(parametros);
            return lista;
        }

        [HttpGet("producto:{IdProducto}")]
        public async Task<ActionResult<List<Mproveedor_producto>>> GetbyIdProducto(int IdProducto)
        {
            var parametros = new Mproveedor_producto();
            parametros.IdProducto = IdProducto;
            var funcion = new Dproveedor_Producto();
            var lista = await funcion.MostrarMostrarProveedor_ProductoPorIdProducto(parametros);
            return lista;
        }

        [HttpGet("fechaobtencion:{FechaObtencion}")]
        public async Task<ActionResult<List<Mproveedor_producto>>> GetbyFechaObtencion(DateOnly FechaObtencion)
        {
            var parametros = new Mproveedor_producto();
            parametros.FechaObtencion = FechaObtencion;
            var funcion = new Dproveedor_Producto();
            var lista = await funcion.MostrarProveedor_ProductoPorFecha(parametros);
            return lista;
        }

        [HttpGet("proveedor:{IdProveedor}/producto:{IdProducto}/fechaobtencion:{FechaObtencion}")]
        public async Task<ActionResult<List<Mproveedor_producto>>> GetbyBothIdAndFechaObtencion(int IdProveedor, int IdProducto,DateOnly FechaObtencion)
        {
            var parametros = new Mproveedor_producto();
            parametros.IdProveedor = IdProveedor;
            parametros.IdProducto = IdProducto;
            parametros.FechaObtencion = FechaObtencion;
            var funcion = new Dproveedor_Producto();
            var lista = await funcion.MostrarProveedor_ProductoPorAmbosIdsYFecha(parametros);
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] Mproveedor_producto parametros)
        {
            var funcion = new Dproveedor_Producto();
            await funcion.InsertarProveedor_Producto(parametros);
        }

        [HttpPut("proveedor:{IdProveedor}/producto:{IdProducto}/fechaobtencion:{FechaObtencion}")]
        public async Task<ActionResult> Put(int IdProveedor, int IdProducto, DateOnly FechaObtencion, [FromBody] Mproveedor_producto parametros)
        {
            var funcion = new Dproveedor_Producto();
            parametros.IdProveedor = IdProveedor;
            parametros.IdProducto = IdProducto;
            parametros.FechaObtencion = FechaObtencion;
            await funcion.EditarProveedor_Producto(parametros);
            return NoContent();
        }

        [HttpDelete("proveedor:{IdProveedor}")]
        public async Task<ActionResult> DeletebyIdProveedor(int IdProveedor)
        {
            var funcion = new Dproveedor_Producto();
            var parametros = new Mproveedor_producto();
            parametros.IdProveedor = IdProveedor;
            await funcion.EliminarProveedor_ProductoPorIdProveedor(parametros);
            return NoContent();
        }

        [HttpDelete("producto:{IdProducto}")]
        public async Task<ActionResult> DeletebyIdProducto(int IdProducto)
        {
            var funcion = new Dproveedor_Producto();
            var parametros = new Mproveedor_producto();
            parametros.IdProducto = IdProducto;
            await funcion.EliminarProveedor_ProductoPorIdProducto(parametros);
            return NoContent();

        }

        [HttpDelete("proveedor:{IdProveedor}/producto:{IdProducto}/fechaobtencion:{FechaObtencion}")]
        public async Task<ActionResult> Delete(int IdProveedor, int IdProducto, DateOnly FechaObtencion)
        {
            var funcion = new Dproveedor_Producto();
            var parametros = new Mproveedor_producto();
            parametros.IdProveedor = IdProveedor;
            parametros.IdProducto = IdProducto;
            parametros.FechaObtencion = FechaObtencion;
            await funcion.eliminarProveedor_ProductoPorAmbosIdsYFecha(parametros);
            return NoContent();

        }
    }
}
