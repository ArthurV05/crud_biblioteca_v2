using Crud_biblioteca.Model;

namespace Crud_biblioteca.Services
{
    internal interface ILivroService
    {
        public bool Inserir(Livro livro);

        public List<Livro> ListarLivros();

        public Livro? BuscarPorId(int id);

        public bool AtualizarLivro(Livro livro);

        public bool AtualizarEstoque(int id, int estoque);

        public bool AtualizarValor(int id, decimal valor);

        public bool DeletarLivro(int id);
    }
}
