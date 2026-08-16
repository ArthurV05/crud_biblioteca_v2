using Crud_biblioteca.Service;


namespace Crud_biblioteca.Controllers
{
    internal class LivroController
    {
        //private readonly LivroService _livroService = new LivroService();

        private readonly LivroService _livroService;

        public LivroController()
        {
            _livroService = new LivroService();
        }

        //Ver regras de negócios
        public void Menu()
        {
            int escolha = 0;
            //Verificar tipo de valor no banco de dados
            
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
                        _livroService.InserirLivro();
                        break;
                    case 2:
                        _livroService.ListarLivros();
                        break;
                    case 3:
                        _livroService.BuscarLivroPorId();
                        break;
                    case 4:
                        _livroService.AtualizarLivro();
                        break;
                    case 5:
                        _livroService.DeletarLivro();
                        break;
                    case 6:
                        Console.Clear();
                        break;
                    case 7:
                        _livroService.SairSistema();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
}
