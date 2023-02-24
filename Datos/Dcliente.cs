using System.Data;
using System.Data.SqlClient;
using ApiRestBambishop.Conexiones;
using ApiRestBambishop.Modelos;

namespace ApiRestBambishop.Datos
{
    public class Dcliente
    {
        ConexionbBd cn = new ConexionbBd();
        public async Task<List<MCliente>> MostrarClientes()
        {
            var lista = new List<MCliente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarClientes", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mcliente = new MCliente();
                            mcliente.IdCliente = (int)item["IdCliente"];
                            mcliente.Nombres = (string)item["Nombres"];
                            mcliente.Apellidos = (string)item["Apellidos"];
                            mcliente.Telefono = (string)item["Telefono"];
                            lista.Add(mcliente);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<MCliente>> MostrarClientePorId(MCliente parametros)
        {
            var lista = new List<MCliente>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarClientePorId", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdCliente", parametros.IdCliente);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mcliente = new MCliente();
                            mcliente.IdCliente = (int)item["IdCliente"];
                            mcliente.Nombres = (string)item["Nombres"];
                            mcliente.Apellidos = (string)item["Apellidos"];
                            mcliente.Telefono = (string)item["Telefono"];
                            lista.Add(mcliente);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarCliente(MCliente parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarCliente", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombres", parametros.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", parametros.Apellidos);
                    cmd.Parameters.AddWithValue("@Telefono", parametros.Telefono);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EditarCliente(MCliente parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarCliente", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdCliente", parametros.IdCliente);
                    cmd.Parameters.AddWithValue("@Nombres", parametros.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", parametros.Apellidos);
                    cmd.Parameters.AddWithValue("@Telefono", parametros.Telefono);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task EliminarCliente(MCliente parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarCliente", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IdCliente", parametros.IdCliente);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}
