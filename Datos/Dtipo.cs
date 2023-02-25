using ApiRestBambishop.Conexiones;
using ApiRestBambishop.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace ApiRestBambishop.Datos
{
    public class Dtipo
    {
        ConexionbBd cn = new ConexionbBd();
        public async Task<List<Mtipo>> MostrarTipos()
        {
            var lista = new List<Mtipo>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarTipos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mtipo = new Mtipo();
                            mtipo.IdTipo = (int)item["IdTipo"];
                            mtipo.Tipo = (string)item["Tipo"];
                            lista.Add(mtipo);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<Mtipo>> MostrarTipoPorId(Mtipo parametros)
        {
            var lista = new List<Mtipo>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarTipoPorId", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdTipo", parametros.IdTipo);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mtipo = new Mtipo();
                            mtipo.IdTipo = (int)item["IdTipo"];
                            mtipo.Tipo = (string)item["Tipo"];
                            lista.Add(mtipo);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarTipo(Mtipo parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarTipo", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Tipo", parametros.Tipo);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarTipo(Mtipo parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarTipo", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdTipo", parametros.IdTipo);
                    cmd.Parameters.AddWithValue("@Tipo", parametros.Tipo);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarTipo(Mtipo parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarTipo", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdTipo", parametros.IdTipo);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
