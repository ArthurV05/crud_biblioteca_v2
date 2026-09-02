using Crud_biblioteca.Model;
using Crud_biblioteca.Repository;

namespace Crud_biblioteca.Service
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

            _livroRepository.Inserir(livro);

            return true;
        }

        public List<Livro> ListarLivros()
        {
            var livros = _livroRepository.ListarLivros();

            if (livros == null)
            {
                return null;
            }

            return livros;
        }

        public Livro BuscarPorId(int id)
        {
            var livro = _livroRepository.BuscarPorId(id);
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado. Informe um Id válido.");
                return null;
            }
            return livro;

        }

        public bool AtualizarLivro(Livro livro)//Refatorar em controller
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

            _livroRepository.Atualizar(livro);

            return true;


        }

        public bool AtualizarEstoque(int id, int estoque)
        {

            if (estoque < 0)
            {
                return false;
            }

            _livroRepository.AtualizarEstoque(id, estoque);
            return true;

        }

        public bool AtualizarValor(int id, decimal valor) //Refatorar Controller
        {

            if (valor < 0)
            {

                return false;
            }

            _livroRepository.AtualizarValor(id, valor);

            return true;
        }

        public bool DeletarLivro(int id)
        {

            var result = _livroRepository.Deletar(id);

            return result;

        }

    }
}
