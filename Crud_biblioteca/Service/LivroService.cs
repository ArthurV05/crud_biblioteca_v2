using Crud_biblioteca.BD;
using Crud_biblioteca.Model;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud_biblioteca.Service
{
    internal class LivroService
    {
        private readonly LivroRepositorio _livroRepositorio;
        public LivroService()
        {
            _livroRepositorio = new LivroRepositorio();
 
        }

        public void InserirLivro()
        {
            try
            {
                Console.WriteLine("Digite o nome do livro:");
                string nome = Console.ReadLine();

                if(nome.IsWhiteSpace()) {
                    Console.WriteLine("O nome não pode ser vazio. Informe um valor válido.");
                    return;
                }

                Console.WriteLine("Dite a quantidade de livros: ");
                int quantidade = int.Parse(Console.ReadLine().ToString());
                if (quantidade < 0)
                {
                    Console.WriteLine("A quantidade não pode ser negativa. Informe um valor válido.");
                    return;
                }

                Console.WriteLine("Dite o valor do livro: ");
                double valor = double.Parse(Console.ReadLine());

                if (valor < 0)
                {
                    Console.WriteLine("O valor não pode ser negativo. Informe um valor válido.");
                    return;
                }

                Livro livro = new Livro(0, nome, quantidade, valor);

                _livroRepositorio.Inserir(livro);

                Console.WriteLine("livro registrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

        }

        public void ListarLivros()
        {
            var livros = _livroRepositorio.Listar();

            foreach (var livro in livros)
            {
                //Console.WriteLine($"Id: {livro.Id}, Nome: {livro.Nome}, Quantidade: {livro.Quantidade}, Valor: {livro.Valor} ");
                Console.WriteLine(livro.ToString());
            }
        }

        public void BuscarLivroPorId()
        {
            Console.WriteLine("Informe o ID do livro que deseja buscar: ");
            try
            {
                bool continuar = true;

                int id = int.Parse(Console.ReadLine());

                var livro = _livroRepositorio.BuscarPorId(id);
                if (livro == null)
                {
                    Console.WriteLine("Livro não encontrado. Informe um Id válido.");
                    return;
                }
                //Console.WriteLine($"Id: {livro.Id}, Nome: {livro.Nome}, Quantidade: {livro.Quantidade}, Valor: {livro.Valor}");
                Console.WriteLine(livro.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        public void AtualizarLivro()
        {
            bool continuar = true;

            Console.WriteLine("Informe o id do livro que será atualizado");
            int id = int.Parse(Console.ReadLine());

            if(_livroRepositorio.BuscarPorId(id) == null)
            {
                Console.WriteLine("Livro não encontrado. Informe um id válido.");
                return;
            }

            while (continuar)
            {
                Console.WriteLine("=====================");
                Console.WriteLine("1 - Atualizar Livro  ");
                Console.WriteLine("2 - Atualizar estoque");
                Console.WriteLine("3 - Atualizar valor  ");
                Console.WriteLine("4 - Sair             ");
                Console.WriteLine("=====================");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Informe o novo nome");
                        string novoNome = Console.ReadLine();

                        if(novoNome.IsWhiteSpace())
                        {
                            Console.WriteLine("O nome não pode ser vazio. Informe um valor válido.");
                            break;
                        }

                        Console.WriteLine("Informe a quantidade");
                        int quantidade = int.Parse(Console.ReadLine());

                        Console.WriteLine("Informe o novo valor");
                        double novoValor = double.Parse(Console.ReadLine());

                        Livro livro = new Livro(id, novoNome, quantidade, novoValor);

                        _livroRepositorio.Atualizar(livro);

                        Console.WriteLine(livro.ToString());

                        break;
                    case 2:
                        Console.WriteLine("Informe o novo estoque");

                        int novoEstoque = int.Parse(Console.ReadLine());
                        if (novoEstoque < 0)
                        {
                            Console.WriteLine("O estoque não pode ser negativo. Informe um valor válido.");
                            break;
                        }

                        _livroRepositorio.AtualizarEstoque(id, novoEstoque);
                        Console.Clear();

                        Console.WriteLine("Estoque atualizado com sucesso!");

                        var livroAtualizado = _livroRepositorio.BuscarPorId(id);

                        Console.WriteLine(livroAtualizado.ToString());
                        continuar = false;
                        break;
                    case 3:
                        Console.WriteLine("Informe o novo valor");
                        novoValor = double.Parse(Console.ReadLine());

                        if(novoValor < 0)
                        {
                            Console.WriteLine("O valor não pode ser negativo. Informe um valor válido.");
                            break;
                        }
                        //Terminar função de atualizar valor

                        break;
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

        public void DeletarLivro()
        {
            Console.WriteLine("Informe o id do livro que será excluido");
            int id = int.Parse(Console.ReadLine());

            var livro = _livroRepositorio.BuscarPorId(id);

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado. Informe um id válido.");
                return;
            }
            _livroRepositorio.Deletar(id);

            Console.WriteLine($"Registro do livro {livro.Nome} excluido com sucesso!");

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
