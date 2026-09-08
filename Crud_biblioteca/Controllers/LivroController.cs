using Crud_biblioteca.Model;
using Crud_biblioteca.Services;
using Crud_biblioteca.UI;


namespace Crud_biblioteca.Controllers
{
    internal class LivroController
    {
        private readonly LivroService _livroService;
        public LivroController()
        {
            _livroService = new LivroService();
        }


        public void Iniciar()
        {
            while (true)
            {
                LivroMenu.Menu();
                int escolha;

                while (!int.TryParse(Console.ReadLine(), out escolha))
                {
                    Console.WriteLine("Erro: Você precisa digitar um número inteiro.");
                    Task.Delay(3000).Wait();
                    LivroMenu.Menu();

                }

                switch (escolha)
                {
                    case 1:
                        Raylane_linda();
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

        public void Raylane_linda()
        {

            Console.WriteLine("Digite o nome do livro:");
            string? nome = Console.ReadLine();

            if (nome is null)
            {
                Console.WriteLine("Entrada encerrada. Cadastro cancelado");
                return;
            }

            Console.WriteLine("Dite a quantidade de livros: ");
            int quantidade;

            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out quantidade))
                {
                    break;
                }
                Console.WriteLine("Erro: O campo quantidade só aceita valores númericos");
                Console.WriteLine("Dite a quantidade de livros: ");
            }

            Console.WriteLine("Dite o valor do livro: ");
            decimal valor;

            while (true)
            {
                string? input = Console.ReadLine();

                if (decimal.TryParse(input, out valor))
                {
                    break;
                }
                Console.WriteLine("Erro: O campo valor só aceita valores númericos");
                Console.WriteLine("Dite o valor do livro: ");
            }
            try
            {
                Livro livro = new(0, nome, quantidade, valor);

                var result = _livroService.Inserir(livro);

                if (result == true)
                {
                    Console.WriteLine("livro registrado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Valores incorretos. Informe corretamente as informações para cadastro dos livros");
                }
            }
            catch (Npgsql.NpgsqlException)
            {
                Console.WriteLine("Não foi possível concluir a operação no banco de dados.");
            }


        }

        public void ListarLivros()
        {
            try
            {
                var livros = _livroService.ListarLivros();

                foreach (var livro in livros)
                {
                    Console.WriteLine(livro.ToString());
                }
            }
            catch (Npgsql.NpgsqlException)
            {
                Console.WriteLine("Não foi possível concluir a operação no banco de dados.");
            }

        }

        public void BuscarLivroPorId()
        {

            Console.WriteLine("Informe o ID do livro que deseja buscar: ");

            int id;
            while (true)
            {
                string? input = Console.ReadLine();
                if (int.TryParse(input, out id))
                {
                    break;
                }
                Console.WriteLine("Erro: O id precisa ser um numeral");
                Task.Delay(2000).Wait();
                Console.WriteLine("Informe o ID do livro que deseja buscar: ");
            }

            try
            {
                var livro = _livroService.BuscarPorId(id);

                if (livro == null)
                {
                    Console.WriteLine("Livro não encontrado, informe um id válido");
                    Task.Delay(2000).Wait();
                    return;
                }

                Console.WriteLine(livro.ToString());
            }
            catch (Npgsql.NpgsqlException)
            {
                Console.WriteLine("Não foi possível concluir a operação no banco de dados.");
            }
        }

        public void AtualizarLivro()
        {
            bool continuar = true;

            Console.WriteLine("Informe o id do livro que será atualizado");

            int id;

            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Erro: O id precisa ser um número inteiro");
                Console.WriteLine("Informe o id do livro que será atualizado");
            }

            try
            {
                var livro = _livroService.BuscarPorId(id);

                if (livro is null)
                {
                    Console.WriteLine("O id informado é invalido. Digite um id correto e tente novamente");
                    Task.Delay(2000).Wait();
                    return;
                }
                while (continuar)
                {
                    LivroMenu.MenuAtualizar();
                    int opcao;

                    while (!int.TryParse(Console.ReadLine(), out opcao))
                    {
                        Console.WriteLine("Erro: Você precisa informar um número inteiro.");
                        LivroMenu.MenuAtualizar();
                    }

                    switch (opcao)
                    {
                        case 1:
                            {
                                Console.WriteLine("Informe o novo nome");
                                string? nome = Console.ReadLine();

                                if (nome is null)
                                {
                                    Console.WriteLine("Entrada encerrada, nome não pode estar vazio");
                                    return;
                                }

                                Console.WriteLine("Informe a quantidade");
                                int quantidade;
                                while (true)
                                {
                                    string? input = Console.ReadLine();

                                    if (!int.TryParse(input, out quantidade))
                                    {
                                        Console.WriteLine("Erro: O campo quantidade precisa ser preenchido por um número inteiro");
                                        Console.WriteLine();
                                        Console.WriteLine("Informe a quantidade");
                                        continue;
                                    }

                                    break;
                                }

                                Console.WriteLine("Informe o novo valor:");

                                decimal novoValor;

                                while (!decimal.TryParse(Console.ReadLine(), out novoValor))
                                {
                                    Console.WriteLine("Erro: O campo valor precisa ser preenchido por um numeral");
                                    Console.WriteLine();
                                    Console.WriteLine("Informe o novo valor:");
                                }

                                Livro novoLivro = new(livro.Id, nome, quantidade, novoValor);

                                var result = _livroService.AtualizarLivro(novoLivro);

                                if (result == true)
                                {
                                    Console.WriteLine("Livro Atualizado com sucesso!");
                                    continuar = false;
                                }
                                else
                                {
                                    Console.WriteLine("Não foi possível atualizar o registro. Verifique os dados e a existência do registro");
                                }

                                break;
                            }

                        case 2:
                            {
                                Console.WriteLine("Informe o novo número de livros em estoque");
                                int novoEstoque;

                                string? input = Console.ReadLine();

                                while (!int.TryParse(input, out novoEstoque))
                                {
                                    Console.WriteLine("O valor do estoque precisa ser um número ");
                                    Console.WriteLine("Informe o novo número em estoque:");
                                    input = Console.ReadLine();
                                }

                                var result = _livroService.AtualizarEstoque(livro.Id, novoEstoque);

                                if (result == true)
                                {
                                    Console.WriteLine("Estoque atualizado com sucesso!");
                                    continuar = false;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Erro: O valor informado encontra-se incorreto. Tente novamente com um número válido");
                                    break;
                                }

                            }

                        case 3:
                            {
                                decimal valor;

                                while (true)
                                {
                                    Console.WriteLine("Informe o valor do livro:");
                                    string? input = Console.ReadLine();

                                    if (decimal.TryParse(input, out valor))
                                    {
                                        break;
                                    }

                                    Console.WriteLine("O valor precisa ser um número.");
                                }

                                var result = _livroService.AtualizarValor(livro.Id, valor);
                                if (result == true)
                                {
                                    Console.WriteLine("Valor atualizado com sucesso!");
                                    continuar = false;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Erro: O valor informado encontra-se incorreto. Tente novamente com um número válido");
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
            catch (Npgsql.NpgsqlException)
            {
                Console.WriteLine("Não foi possível concluir a operação no banco de dados.");

            }

        }

        public void DeletarLivro()
        {
            Console.WriteLine("Informe o Id do livro:");
            int id;

            while (!int.TryParse(Console.ReadLine(), out id))
            {

                Console.WriteLine("Id Inválido. Informe um número válido");
                Console.WriteLine("Informe o Id do livro");
            }
            try
            {
                var result = _livroService.DeletarLivro(id);
                if (result == true)
                {
                    Console.WriteLine("Livro apagado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não existe um livro com este número de ID. Informe um livro existente");
                }
            }
            catch (Npgsql.NpgsqlException)
            {
                Console.WriteLine("Não foi possível concluir a operação no banco de dados.");

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
