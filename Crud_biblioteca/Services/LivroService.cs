using Crud_biblioteca.Model;
using Crud_biblioteca.Repository;

namespace Crud_biblioteca.Services
{
    internal class LivroService : ILivroService
    {
        private readonly LivroRepository _livroRepository;
        public LivroService()
        {
            _livroRepository = new LivroRepository();

        }

        public bool Inserir(Livro livro)
        {

            if (string.IsNullOrWhiteSpace(livro.Nome) || livro.Quantidade < 0)
            {
                return false;
            }

            if (livro.Valor < 0)
            {

                return false;
            }

            var result = _livroRepository.Inserir(livro);

            return result;
        }

        public List<Livro> ListarLivros()
        {
            var livros = _livroRepository.ListarLivros();

            return livros;
        }

        public Livro? BuscarPorId(int id)
        {
            var livro = _livroRepository.BuscarPorId(id);

            if (livro == null)
            {

                return null;
            }
            return livro;

        }

        public bool AtualizarLivro(Livro livro)
        {

            if (string.IsNullOrWhiteSpace(livro.Nome))
            {
                return false;
            }

            if (livro.Quantidade < 0)
            {
                return false;
            }

            if (livro.Valor < 0)
            {
                return false;
            }

            var result = _livroRepository.Atualizar(livro);

            return result;


        }

        public bool AtualizarEstoque(int id, int estoque)
        {

            if (estoque < 0)
            {
                return false;
            }

            var result = _livroRepository.AtualizarEstoque(id, estoque);
            return result;

        }

        public bool AtualizarValor(int id, decimal valor) //Refatorar Controller
        {

            if (valor < 0)
            {

                return false;
            }
            var result = _livroRepository.AtualizarValor(id, valor);
            return result;
        }

        public bool DeletarLivro(int id)
        {

            var result = _livroRepository.Deletar(id);

            return result;

        }

    }
}
