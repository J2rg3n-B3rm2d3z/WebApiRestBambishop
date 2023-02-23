using System.Data;
using System.Data.SqlClient;
using ApiRestBambishop.Conexiones;
using ApiRestBambishop.Modelos;

namespace ApiRestBambishop.Datos
{
    public class Dcliente
    {
        ConexionbBd cn = new ConexionbBd();
        public async Task<List<Mcliente>> Mostrarclientes()
        {
            var lista = new List<Mcliente>();
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
                            var mcliente = new Mcliente();
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

        public async Task<List<Mcliente>> MostrarClientePorId(Mcliente parametros)
        {
            var lista = new List<Mcliente>();
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
                            var mcliente = new Mcliente();
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
    }
}
