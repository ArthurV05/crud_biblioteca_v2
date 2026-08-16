using Crud_biblioteca.Controllers;
using Npgsql.Replication;
using System.Runtime.CompilerServices;

internal class Program
{
    private LivroController _livroController;


    private Program()
    {
        _livroController = new LivroController();
    }

    private static void Main(string[] args)
    {
        var program = new Program();
        program._livroController.Menu();

    }
}


