using Crud_biblioteca.Controllers;

namespace Crud_biblioteca.UI
{
    internal class LivroMenu
    {
        private readonly LivroController _livroController;
        public LivroMenu() 
        { 
            _livroController = new LivroController();
        }

        public void Menu()
        {
            int escolha = 0;

            while (true)
            {
                Console.WriteLine("========================");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Inserir livro");
                Console.WriteLine("2 - Listar livros");
                Console.WriteLine("3 - Buscar livro por ID");
                Console.WriteLine("4 - Atualizar livro");
                Console.WriteLine("5 - Excluir livro");
                Console.WriteLine("6 - Limpar tela");
                Console.WriteLine("7 - Sair");
                Console.WriteLine("========================");

                try
                {
                    escolha = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Erro: {ex.Message}");
                }

                switch (escolha)
                {
                    case 1:
                        _livroController.InserirLivro();
                        break;
                    case 2:
                        _livroController.ListarLivros();
                        break;
                    case 3:
                        _livroController.BuscarLivroPorId();
                        break;
                    case 4:
                        _livroController.AtualizarLivro();
                        break;
                    case 5:
                        _livroController.DeletarLivro();
                        break;
                    case 6:
                        Console.Clear();
                        break;
                    case 7:
                        _livroController.SairSistema();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
}
