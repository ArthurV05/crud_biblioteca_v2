using Crud_biblioteca.Model;
using Crud_biblioteca.DATA;
using Dapper;


namespace Crud_biblioteca.Repository
{
    internal class LivroRepositorio
    {

       public bool Inserir(Livro livro)
        {
            using var conn = new ConexaoBD();

            string query = @"INSERT INTO livros (nome, quantidade, valor)
                            VALUES (@nome, @quantidade, @valor)";

            var result = conn.Conexao.Execute(query, livro);

            return result == 1;
        }

        public Livro BuscarPorId(int id)
        {
            using var conn = new ConexaoBD();

            string query = "SELECT * FROM livros WHERE id = @id";

            Livro livro = conn.Conexao.Query<Livro>(query, new { id }).FirstOrDefault();

            return livro;

        }

        public List<Livro> Listar()
        {
            using var conn = new ConexaoBD();

            string query = @" 
                           SELECT * 
                           FROM livros";

            var livros = conn.Conexao.Query<Livro>(query);

            return livros.ToList();
        }

        public bool Atualizar(Livro livro)
        {
            using var conn = new ConexaoBD();

            string query = @"
                            UPDATE livros
                            SET
                                nome = @Nome,
                                quantidade = @Quantidade,
                                valor = @Valor
                            WHERE id = @Id";

            var result = conn.Conexao.Execute(query, livro);
            
            return result == 1;
        }

        public bool AtualizarEstoque(int id, int quantidade)
        {
            using var conn = new ConexaoBD();

            string query = @"
                           UPDATE livros
                            SET
                                quantidade = @quantidade
                            Where id = @id";

            var result = conn.Conexao.Execute(query, new {id, quantidade});

            return result == 1;
        }
        public bool Deletar(int id)
        {
            using var conn = new ConexaoBD();

            string query = @"
                            DELETE FROM livros 
                            WHERE 
                                id = @id";

            var result = conn.Conexao.Execute(query, new { id });

            return result == 1;
        }
    }
}
