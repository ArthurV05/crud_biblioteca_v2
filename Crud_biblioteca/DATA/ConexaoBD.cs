using Npgsql;

namespace Crud_biblioteca.DATA
{
    public class ConexaoBD : IDisposable
    {
        public NpgsqlConnection Conexao { get; set; }

        public ConexaoBD()
        {
            Conexao = new NpgsqlConnection(
                "Host=localhost;" +
                "Port=5432;" +
                "Username=postgres;" +
                "Password=postgres123;" +
                "Database=Crud_biblioteca"
            );
            Conexao.Open();
        }
            public void Dispose()
            {
                Conexao.Close();
                Conexao.Dispose();
                    
                
            }
    }
}