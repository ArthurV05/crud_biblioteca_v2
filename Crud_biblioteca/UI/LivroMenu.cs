using Crud_biblioteca.Controllers;


namespace Crud_biblioteca.UI
{
    internal class LivroMenu
    {


        public static void Menu()
        {
            Console.WriteLine("========================");
            Console.WriteLine("  Escolha uma opção:");
            Console.WriteLine("1 - Inserir livro");
            Console.WriteLine("2 - Listar livros");
            Console.WriteLine("3 - Buscar livro por ID");
            Console.WriteLine("4 - Atualizar livro");
            Console.WriteLine("5 - Excluir livro");
            Console.WriteLine("6 - Limpar tela");
            Console.WriteLine("7 - Sair");
            Console.WriteLine("========================");
        }

        public static void MenuAtualizar()
        {

            Console.WriteLine("=====================");
            Console.WriteLine("  Escolha uma opção: ");
            Console.WriteLine("1 - Atualizar Livro  ");
            Console.WriteLine("2 - Atualizar estoque");
            Console.WriteLine("3 - Atualizar valor  ");
            Console.WriteLine("4 - Sair             ");
            Console.WriteLine("=====================");

        }
    }
}
