using Crud_biblioteca.Model;

namespace Crud_biblioteca.Repository
{
    internal interface ILivroRepository
    {

        public bool Inserir(Livro livro);

        public Livro? BuscarPorId(int id);

        public List<Livro> ListarLivros();

        public bool Atualizar(Livro livro);

        public bool AtualizarEstoque(int id, int estoque);

        public bool AtualizarValor(int id, decimal valor);

        public bool Deletar(int id);
    }
}
