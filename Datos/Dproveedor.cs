using ApiRestBambishop.Conexiones;
using ApiRestBambishop.Modelos;
using System.Data.SqlClient;
using System.Data;

namespace ApiRestBambishop.Datos
{
    public class Dproveedor
    {
        ConexionbBd cn = new ConexionbBd();
        public async Task<List<Mproveedor>> MostrarProveedores()
        {
            var lista = new List<Mproveedor>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarProveedor", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproveedor = new Mproveedor();
                            mproveedor.IdProveedor = (int)item["IdProveedor"];
                            mproveedor.NombreProveedor = (string)item["NombreProveedor"];
                            mproveedor.Direccion = (string)item["Direccion"];
                            if (!item.IsDBNull(item.GetOrdinal("Correo")))
                                mproveedor.Correo = (string)item["Correo"];
                            if (!item.IsDBNull(item.GetOrdinal("Telefono")))
                                mproveedor.Telefono = (string)item["Telefono"];
                            lista.Add(mproveedor);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task<List<Mproveedor>> MostrarProveedorPorId(Mproveedor parametros)
        {
            var lista = new List<Mproveedor>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("mostrarProveedorPorId", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProveedor", parametros.IdProveedor);

                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var mproveedor = new Mproveedor();
                            mproveedor.IdProveedor = (int)item["IdProveedor"];
                            mproveedor.NombreProveedor = (string)item["NombreProveedor"];
                            mproveedor.Direccion = (string)item["Direccion"];
                            if (!item.IsDBNull(item.GetOrdinal("Correo")))
                                mproveedor.Correo = (string)item["Correo"];
                            if (!item.IsDBNull(item.GetOrdinal("Telefono")))
                                mproveedor.Telefono = (string)item["Telefono"];
                            lista.Add(mproveedor);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarProveedor(Mproveedor parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreProveedor", parametros.NombreProveedor);
                    cmd.Parameters.AddWithValue("@Direccion", parametros.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", SqlDbType.NChar).Value = (object)parametros.Telefono ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@Correo", SqlDbType.NVarChar).Value = (object)parametros.Correo ?? DBNull.Value;
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EditarProveedor(Mproveedor parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProveedor", parametros.IdProveedor);
                    cmd.Parameters.AddWithValue("@NombreProveedor", parametros.NombreProveedor);
                    cmd.Parameters.AddWithValue("@Direccion", parametros.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", SqlDbType.NChar).Value = (object) parametros.Telefono ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@Correo", SqlDbType.NVarChar).Value = (object)parametros.Correo ?? DBNull.Value;
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EliminarProveedor(Mproveedor parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarProveedor", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdProveedor", parametros.IdProveedor);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
