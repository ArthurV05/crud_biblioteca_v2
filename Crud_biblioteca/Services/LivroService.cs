using Crud_biblioteca.Model;
using Crud_biblioteca.Repository;

namespace Crud_biblioteca.Service
{
    internal class LivroService : ILivroServiceInterface
    {
        private readonly LivroRepository _livroRepository;
        public LivroService()
        {
            _livroRepository = new LivroRepository();
 
        }

        public Livro Inserir(Livro livro) 
        {
            try
            {
                var id = _livroRepository.BuscarPorId(livro.Id);
                if (id == null)
                {
                    Console.WriteLine("Erro: Id inválido");
                    return null;
                }

                if (livro.Nome.IsWhiteSpace())
                {
                    Console.WriteLine("Nome do livro vazio. Digite um nome válido");
                    return null;
                }

                if (livro.Quantidade < 0 || livro.Quantidade == null)
                {
                    Console.WriteLine("Erro: Um livro não poder ter uma quantidade negativa");
                    return null;
                }

                if (livro.Valor < 0)
                {
                    Console.WriteLine("Erro: O valor do livro não poder ser negativo");
                    return null;
                }

                _livroRepository.Inserir(livro);

                return livro;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }

        public List<Livro> ListarLivros()
        {
            var livros = _livroRepository.ListarLivros();

            if(livros == null) 
            { 
                return null; 
            }

            return livros;
        }

        public Livro BuscarPorId(int id)
        {
            try
            {
                var livro = _livroRepository.BuscarPorId(id);
                if (livro == null)

                {
                    Console.WriteLine("Livro não encontrado. Informe um Id válido.");
                    return null;
                }
                return livro;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Erro: {ex.Message}");
                return null;
            }

        }

        public Livro AtualizarLivro(Livro livro)
        {
            try
            {
                if(livro.Quantidade < 0)
                {
                    Console.WriteLine("Erro: A quantidade de livros não pode ser menor que zero");
                }

                if(livro.Valor < 0)
                {
                    Console.WriteLine("Erro: O valor do livro não pode ser menor que zero");
                }

                _livroRepository.Atualizar(livro);

                return livro;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }

        public int AtualizarEstoque(int id,int estoque)
        {
            if(estoque > 0)
            {
                Console.WriteLine("Erro: O estoque não pode ser um valor menor que zero");
            }

            _livroRepository.AtualizarEstoque(id, estoque);

            return estoque;

        }
    }
}
