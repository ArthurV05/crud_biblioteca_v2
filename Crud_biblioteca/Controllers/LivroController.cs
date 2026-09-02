using Crud_biblioteca.Model;
using Crud_biblioteca.Service;
using Crud_biblioteca.UI;


namespace Crud_biblioteca.Controllers
{
    internal class LivroController
    {

        private readonly LivroService _livroService;

        private readonly LivroMenu _livroMenu;
        public LivroController()
        {
            _livroService = new LivroService();
        }

        public void Iniciar()
        {
            while (true)
            {
                LivroMenu.Menu();
                int escolha = 0;
                try
                {
                    escolha = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                switch (escolha)
                {
                    case 1:
                        InserirLivro();
                        break;
                    case 2:
                        ListarLivros();
                        break;
                    case 3:
                        BuscarLivroPorId();
                        break;
                    case 4:
                        AtualizarLivro();
                        break;
                    case 5:
                        DeletarLivro();
                        break;
                    case 6:
                        Console.Clear();
                        break;
                    case 7:
                        SairSistema();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }

        }


        public void InserirLivro() //Testar TryParse, posteriormente, espalhar para todo o controller
        {
            //try
            //{
            Console.WriteLine("Digite o nome do livro:");
            string nome = Console.ReadLine();

            Console.WriteLine("Dite a quantidade de livros: ");
            int quantidade = int.TryParse(Console.ReadLine().ToString());

            Console.WriteLine("Dite o valor do livro: ");
            double valor = double.Parse(Console.ReadLine());

            Livro livro = new Livro(0, nome, quantidade, valor);

            var result = _livroService.Inserir(livro);

            if (result == true)
            {
                Console.WriteLine("livro registrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Valores incorretos. Informe corretamente as informações para cadastro dos livros");
            }
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine($"Erro: {ex.Message}");
            // }

        }

        public void ListarLivros()
        {
            var livros = _livroService.ListarLivros();

            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToString());
            }
        }

        public void BuscarLivroPorId()
        {
            Console.WriteLine("Informe o ID do livro que deseja buscar: ");
            try
            {
                int id = int.Parse(Console.ReadLine());

                var livro = _livroService.BuscarPorId(id);

                if (livro != null)
                    Console.WriteLine(livro.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AtualizarLivro() //Refatorar controller 
        {
            bool continuar = true;

            Console.WriteLine("Informe o id do livro que será atualizado");

            int id = int.Parse(Console.ReadLine());
            var livro = _livroService.BuscarPorId(id);

            if (livro == null)
                continuar = false;

            while (continuar)
            {
                LivroMenu.MenuAtualizar();
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        {
                            try
                            {
                                Console.WriteLine("Informe o novo nome");
                                string novoNome = Console.ReadLine();

                                Console.WriteLine("Informe a quantidade");
                                int quantidade = int.Parse(Console.ReadLine());

                                Console.WriteLine("Informe o novo valor");
                                double novoValor = double.Parse(Console.ReadLine());

                                Livro novoLivro = new Livro(livro.Id, novoNome, quantidade, novoValor);

                                var result = _livroService.AtualizarLivro(novoLivro);

                                if (result == true)
                                {
                                    Console.WriteLine("Livro Atualizado com sucesso!");
                                    continuar = false;
                                }
                                else
                                {
                                    Console.WriteLine("Erros no preenchimento dos campos. Informe todos os campos corretamente");
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            break;
                        }

                    case 2:
                        {
                            try
                            {
                                Console.WriteLine("Informe o novo número em estoque");

                                int novoEstoque = int.Parse(Console.ReadLine());

                                var result = _livroService.AtualizarEstoque(livro.Id, novoEstoque);

                                if (result == true)
                                {
                                    Console.WriteLine("Estoque atualizado com sucesso!");
                                    continuar = false;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Erro: O estoque não pode ser menor que zero");
                                    break;
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                break;
                            }
                        }

                    case 3:
                        {
                            try
                            {
                                Console.WriteLine("Informe o novo valor");

                                var valorNovo = decimal.Parse(Console.ReadLine());
                                var result = _livroService.AtualizarValor(livro.Id, valorNovo);

                                if (result == true)
                                {
                                    Console.WriteLine("Valor atualizado com sucesso!");
                                    continuar = false;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Erro: O valor não pode ser negativo");
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                break;
                            }

                        }

                    case 4:
                        continuar = false;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }

        public void DeletarLivro() //Colocar uma validação para o id (tryparse?)
        {
            Console.WriteLine("Informe o id do livro que será excluido");
            int id = int.Parse(Console.ReadLine());

            var result = _livroService.DeletarLivro(id);
            if (result == true)
            {
                Console.WriteLine("Livro apagado com sucesso!");
            }
            else
            {
                Console.WriteLine("Não foi possível apagar o livro. Certifique-se que o id esteja correto");
            }
        }

        public void SairSistema()
        {
            Console.WriteLine("Saindo do sistema...");
            Task.Delay(1000).Wait();
            Console.WriteLine("Pronto, até a próxima!");
            Environment.Exit(0);

        }

    }
}
