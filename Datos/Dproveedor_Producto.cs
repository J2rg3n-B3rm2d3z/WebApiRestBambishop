using ApiRestBambishop.Conexiones;
using ApiRestBambishop.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace ApiRestBambishop.Datos
{
    public class Dproveedor_Producto
    {
        ConexionbBd cn = new ConexionbBd();
        public async Task<List<Mproveedor_producto>> MostrarProveedor_Producto()
        {
            var lista = new List<Mproveedor_producto>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarProveedor_Producto", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproveedor_producto = new Mproveedor_producto();
                            mproveedor_producto.IdProducto = (int)item["IdProducto"];
                            mproveedor_producto.IdProveedor = (int)item["IdProveedor"];
                            var Fechatemp = (DateTime)item["FechaObtencion"];
                            mproveedor_producto.FechaObtencion = new DateOnly(Fechatemp.Year, Fechatemp.Month, Fechatemp.Day);
                            mproveedor_producto.CostoTotal = (decimal)item["CostoTotal"];
                            mproveedor_producto.CantidadObtenida = (int)item["CantidadObtenida"];
                            lista.Add(mproveedor_producto);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task<List<Mproveedor_producto>> MostrarMostrarProveedor_ProductoPorIdProducto(Mproveedor_producto parametros)
        {
            var lista = new List<Mproveedor_producto>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarProveedor_ProductoPorIdProducto", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", parametros.IdProducto);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproveedor_producto = new Mproveedor_producto();
                            mproveedor_producto.IdProducto = (int)item["IdProducto"];
                            mproveedor_producto.IdProveedor = (int)item["IdProveedor"];
                            var Fechatemp = (DateTime)item["FechaObtencion"];
                            mproveedor_producto.FechaObtencion = new DateOnly(Fechatemp.Year, Fechatemp.Month, Fechatemp.Day);
                            mproveedor_producto.CostoTotal = (decimal)item["CostoTotal"];
                            mproveedor_producto.CantidadObtenida = (int)item["CantidadObtenida"];
                            lista.Add(mproveedor_producto);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task<List<Mproveedor_producto>> MostrarMostrarProveedor_ProductoPorIdProveedor(Mproveedor_producto parametros)
        {
            var lista = new List<Mproveedor_producto>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarProveedor_ProductoPorIdProveedor", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProveedor", parametros.IdProveedor);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproveedor_producto = new Mproveedor_producto();
                            mproveedor_producto.IdProducto = (int)item["IdProducto"];
                            mproveedor_producto.IdProveedor = (int)item["IdProveedor"];
                            var Fechatemp = (DateTime)item["FechaObtencion"];
                            mproveedor_producto.FechaObtencion = new DateOnly(Fechatemp.Year, Fechatemp.Month, Fechatemp.Day);
                            mproveedor_producto.CostoTotal = (decimal)item["CostoTotal"];
                            mproveedor_producto.CantidadObtenida = (int)item["CantidadObtenida"];
                            lista.Add(mproveedor_producto);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task<List<Mproveedor_producto>> MostrarProveedor_ProductoPorFecha(Mproveedor_producto parametros)
        {
            var lista = new List<Mproveedor_producto>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarProveedor_ProductoPorFecha", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaObtencion", new DateTime(parametros.FechaObtencion.Year, parametros.FechaObtencion.Month, parametros.FechaObtencion.Day));

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproveedor_producto = new Mproveedor_producto();
                            mproveedor_producto.IdProducto = (int)item["IdProducto"];
                            mproveedor_producto.IdProveedor = (int)item["IdProveedor"];
                            var Fechatemp = (DateTime)item["FechaObtencion"];
                            mproveedor_producto.FechaObtencion = new DateOnly(Fechatemp.Year, Fechatemp.Month, Fechatemp.Day);
                            mproveedor_producto.CostoTotal = (decimal)item["CostoTotal"];
                            mproveedor_producto.CantidadObtenida = (int)item["CantidadObtenida"];
                            lista.Add(mproveedor_producto);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task<List<Mproveedor_producto>> MostrarProveedor_ProductoPorAmbosIdsYFecha(Mproveedor_producto parametros)
        {
            var lista = new List<Mproveedor_producto>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarProveedor_ProductoPorAmbosIdsYFecha", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", parametros.IdProducto);
                    cmd.Parameters.AddWithValue("@IdProveedor", parametros.IdProveedor);
                    cmd.Parameters.AddWithValue("@FechaObtencion", new DateTime(parametros.FechaObtencion.Year, parametros.FechaObtencion.Month, parametros.FechaObtencion.Day));

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproveedor_producto = new Mproveedor_producto();
                            mproveedor_producto.IdProducto = (int)item["IdProducto"];
                            mproveedor_producto.IdProveedor = (int)item["IdProveedor"];
                            var Fechatemp = (DateTime)item["FechaObtencion"];
                            mproveedor_producto.FechaObtencion = new DateOnly(Fechatemp.Year, Fechatemp.Month, Fechatemp.Day);
                            mproveedor_producto.CostoTotal = (decimal)item["CostoTotal"];
                            mproveedor_producto.CantidadObtenida = (int)item["CantidadObtenida"];
                            lista.Add(mproveedor_producto);
                        }
                    }
                }
            }
            return lista;
        }
        public async Task InsertarProveedor_Producto(Mproveedor_producto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarProveedor_Producto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", parametros.IdProducto);
                    cmd.Parameters.AddWithValue("@IdProveedor", parametros.IdProveedor);
                    cmd.Parameters.AddWithValue("@FechaObtencion", new DateTime(parametros.FechaObtencion.Year, parametros.FechaObtencion.Month, parametros.FechaObtencion.Day));
                    cmd.Parameters.AddWithValue("@CostoTotal", parametros.CostoTotal);
                    cmd.Parameters.AddWithValue("@CantidadObtenida", parametros.CantidadObtenida);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task EditarProveedor_Producto(Mproveedor_producto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarProveedor_Producto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", parametros.IdProducto);
                    cmd.Parameters.AddWithValue("@IdProveedor", parametros.IdProveedor);
                    cmd.Parameters.AddWithValue("@FechaObtencion", new DateTime(parametros.FechaObtencion.Year, parametros.FechaObtencion.Month, parametros.FechaObtencion.Day));
                    cmd.Parameters.AddWithValue("@CostoTotal", parametros.CostoTotal);
                    cmd.Parameters.AddWithValue("@CantidadObtenida", parametros.CantidadObtenida);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task EliminarProveedor_ProductoPorIdProveedor(Mproveedor_producto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarProveedor_ProductoPorIdProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProveedor", parametros.IdProveedor);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task EliminarProveedor_ProductoPorIdProducto(Mproveedor_producto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarProveedor_ProductoPorIdProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", parametros.IdProducto);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task eliminarProveedor_ProductoPorAmbosIdsYFecha(Mproveedor_producto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarProveedor_ProductoPorAmbosIdsYFecha", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@IdProducto", parametros.IdProducto);
                    cmd.Parameters.AddWithValue("@IdProveedor", parametros.IdProveedor);
                    cmd.Parameters.AddWithValue("@FechaObtencion", new DateTime(parametros.FechaObtencion.Year, parametros.FechaObtencion.Month, parametros.FechaObtencion.Day));

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
