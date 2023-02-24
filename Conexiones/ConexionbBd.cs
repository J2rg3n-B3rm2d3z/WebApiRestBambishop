namespace ApiRestBambishop.Conexiones
{
    public class ConexionbBd
    {
        private string connectionString = string.Empty;
        public ConexionbBd()
        {

            var constructor = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            connectionString = constructor.GetSection("ConnectionStrings:conexionmaestra").Value;

        }
        public string cadenaSQL()
        {
            return connectionString;
        }
    }
}
