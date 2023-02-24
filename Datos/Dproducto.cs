using ApiRestBambishop.Conexiones;
using ApiRestBambishop.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace ApiRestBambishop.Datos
{
    public class Dproducto
    {
        ConexionbBd cn = new ConexionbBd();
        public async Task<List<Mproducto>> MostrarProductos()
        {
            var lista = new List<Mproducto>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarProductos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproducto = new Mproducto();
                            mproducto.IdProducto = (int)item["IdProducto"];
                            mproducto.IdTipo = (int)item["IdTipo"];
                            mproducto.NombreProducto = (string)item["NombreProducto"];
                            mproducto.PrecioActual = (decimal)item["PrecioActual"];
                            mproducto.CantidadProducto = (int)item["CantidadProducto"];
                            lista.Add(mproducto);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<Mproducto>> MostrarProductoPorId(Mproducto parametros)
        {
            var lista = new List<Mproducto>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarProductoPorId", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProducto", parametros.IdProducto);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproducto = new Mproducto();
                            mproducto.IdProducto = (int)item["IdProducto"];
                            mproducto.IdTipo = (int)item["IdTipo"];
                            mproducto.NombreProducto = (string)item["NombreProducto"];
                            mproducto.PrecioActual = (decimal)item["PrecioActual"];
                            mproducto.CantidadProducto = (int)item["CantidadProducto"];
                            lista.Add(mproducto);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarProducto(Mproducto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdTipo", parametros.IdTipo);
                    cmd.Parameters.AddWithValue("@NombreProducto", parametros.NombreProducto);
                    cmd.Parameters.AddWithValue("@PrecioActual", parametros.PrecioActual);
                    cmd.Parameters.AddWithValue("@CantidadProducto", parametros.CantidadProducto);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarProducto(Mproducto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdProducto", parametros.IdProducto);
                    cmd.Parameters.AddWithValue("@IdTipo", parametros.IdTipo);
                    cmd.Parameters.AddWithValue("@NombreProducto", parametros.NombreProducto);
                    cmd.Parameters.AddWithValue("@PrecioActual", parametros.PrecioActual);
                    cmd.Parameters.AddWithValue("@CantidadProducto", parametros.CantidadProducto);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarProducto(Mproducto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarProducto", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdProducto", parametros.IdProducto);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
