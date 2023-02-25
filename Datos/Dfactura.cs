using ApiRestBambishop.Conexiones;
using ApiRestBambishop.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace ApiRestBambishop.Datos
{
    public class Dfactura
    {
        ConexionbBd cn = new ConexionbBd();
        public async Task<List<Mfactura>> MostrarFacturas()
        {
            var lista = new List<Mfactura>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarFacturas", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mfactura = new Mfactura();
                            mfactura.IdFactura = (int)item["IdFactura"];
                            mfactura.IdCliente = (int)item["IdCliente"];
                            var Fechatemp = (DateTime)item["FechaEmision"];
                            mfactura.FechaEmision = new DateOnly(Fechatemp.Year,Fechatemp.Month,Fechatemp.Day);
                            mfactura.Impuestos = (decimal)item["Impuestos"];
                            mfactura.Descuento = (decimal)item["Descuento"];
                            lista.Add(mfactura);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<Mfactura>> MostrarFacturaPorId(Mfactura parametros)
        {
            var lista = new List<Mfactura>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarFacturaPorId", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdFactura", parametros.IdFactura);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mfactura = new Mfactura();
                            mfactura.IdFactura = (int)item["IdFactura"];
                            mfactura.IdCliente = (int)item["IdCliente"];
                            var Fechatemp = (DateTime)item["FechaEmision"];
                            mfactura.FechaEmision = new DateOnly(Fechatemp.Year, Fechatemp.Month, Fechatemp.Day);
                            mfactura.Impuestos = (decimal)item["Impuestos"];
                            mfactura.Descuento = (decimal)item["Descuento"];
                            lista.Add(mfactura);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarFactura(Mfactura parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarFactura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCliente", parametros.IdCliente);
                    cmd.Parameters.AddWithValue("@FechaEmision", new DateTime(parametros.FechaEmision.Year, parametros.FechaEmision.Month, parametros.FechaEmision.Day));
                    cmd.Parameters.AddWithValue("@Impuestos", parametros.Impuestos);
                    cmd.Parameters.AddWithValue("@Descuento", parametros.Descuento);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EditarFactura(Mfactura parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarFactura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdFactura", parametros.IdFactura);
                    cmd.Parameters.AddWithValue("@IdCliente", parametros.IdCliente);
                    cmd.Parameters.AddWithValue("@FechaEmision", new DateTime(parametros.FechaEmision.Year, parametros.FechaEmision.Month,parametros.FechaEmision.Day));
                    cmd.Parameters.AddWithValue("@Impuestos", parametros.Impuestos);
                    cmd.Parameters.AddWithValue("@Descuento", parametros.Descuento);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarFactura(Mfactura parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarFactura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdFactura", parametros.IdFactura);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
