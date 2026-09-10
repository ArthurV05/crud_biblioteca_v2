using Npgsql;

namespace Crud_biblioteca.DATA
{
    public class ConexaoBD : IDisposable
    {
        public NpgsqlConnection Conexao { get; set; }

        public ConexaoBD()
        {
            string? connectionString = 
            Environment.GetEnvironmentVariable("BIBLIOTECA_CONNECTION_STRING");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Configure a variável de ambiente BIBLIOTECA_CONNECTION_STRING");

            Conexao = new NpgsqlConnection(connectionString);
            Conexao.Open();
        }
        public void Dispose()
        {
            Conexao.Close();
            Conexao.Dispose();

        }
    }
}