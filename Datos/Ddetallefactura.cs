using ApiRestBambishop.Conexiones;
using ApiRestBambishop.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace ApiRestBambishop.Datos
{
    public class Ddetallefactura
    {
        ConexionbBd cn = new ConexionbBd();
        public async Task<List<Mdetallefactura>> MostrarDetalleFacturas()
        {
            var lista = new List<Mdetallefactura>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarDetalleFacturas", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mdetallefactura = new Mdetallefactura();
                            mdetallefactura.IdProducto = (int)item["IdProducto"];
                            mdetallefactura.IdFactura = (int)item["IdFactura"];
                            mdetallefactura.PrecioVenta = (decimal)item["PrecioVenta"];
                            mdetallefactura.CantidadVendida = (int)item["CantidadVendida"];
                            lista.Add(mdetallefactura);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<Mdetallefactura>> MostrarDetalleFacturasPorIdFactura(Mdetallefactura parametros)
        {
            var lista = new List<Mdetallefactura>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarDetalleFacturaPorIdFactura", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdFactura", parametros.IdFactura);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mdetallefactura = new Mdetallefactura();
                            mdetallefactura.IdProducto = (int)item["IdProducto"];
                            mdetallefactura.IdFactura = (int)item["IdFactura"];
                            mdetallefactura.PrecioVenta = (decimal)item["PrecioVenta"];
                            mdetallefactura.CantidadVendida = (int)item["CantidadVendida"];
                            lista.Add(mdetallefactura);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<Mdetallefactura>> MostrarDetalleFacturasPorIdProducto(Mdetallefactura parametros)
        {
            var lista = new List<Mdetallefactura>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarDetalleFacturaPorIdProducto", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", parametros.IdProducto);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mdetallefactura = new Mdetallefactura();
                            mdetallefactura.IdProducto = (int)item["IdProducto"];
                            mdetallefactura.IdFactura = (int)item["IdFactura"];
                            mdetallefactura.PrecioVenta = (decimal)item["PrecioVenta"];
                            mdetallefactura.CantidadVendida = (int)item["CantidadVendida"];
                            lista.Add(mdetallefactura);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<Mdetallefactura>> MostrarDetalleFacturasPorAmbosId(Mdetallefactura parametros)
        {
            var lista = new List<Mdetallefactura>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarDetalleFacturaPorAmbosIds", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdFactura", parametros.IdFactura);
                    cmd.Parameters.AddWithValue("@IdProducto", parametros.IdProducto);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mdetallefactura = new Mdetallefactura();
                            mdetallefactura.IdProducto = (int)item["IdProducto"];
                            mdetallefactura.IdFactura = (int)item["IdFactura"];
                            mdetallefactura.PrecioVenta = (decimal)item["PrecioVenta"];
                            mdetallefactura.CantidadVendida = (int)item["CantidadVendida"];
                            lista.Add(mdetallefactura);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarDetalleFactura(Mdetallefactura parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarDetalleFactura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", parametros.IdProducto);
                    cmd.Parameters.AddWithValue("@IdFactura", parametros.IdFactura);
                    cmd.Parameters.AddWithValue("@PrecioVenta", parametros.PrecioVenta);
                    cmd.Parameters.AddWithValue("@CantidadVendida", parametros.CantidadVendida);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EditarDetalleFactura(Mdetallefactura parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarDetalleFactura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", parametros.IdProducto);
                    cmd.Parameters.AddWithValue("@IdFactura", parametros.IdFactura);
                    cmd.Parameters.AddWithValue("@PrecioVenta", parametros.PrecioVenta);
                    cmd.Parameters.AddWithValue("@CantidadVendida", parametros.CantidadVendida);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarDetalleFacturaPorIdFactura(Mdetallefactura parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarDetalleFacturaPorIdFactura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdFactura", parametros.IdFactura);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarDetalleFacturaPorIdProducto(Mdetallefactura parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarDetalleFacturaPorIdProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", parametros.IdProducto);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task eliminarDetalleFacturaPorAmbosIds(Mdetallefactura parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarDetalleFacturaPorAmbosIds", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", parametros.IdProducto);
                    cmd.Parameters.AddWithValue("@IdFactura", parametros.IdFactura);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

    }
}
