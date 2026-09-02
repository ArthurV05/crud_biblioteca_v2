using Crud_biblioteca.Controllers;
using Crud_biblioteca.UI;

internal class Program
{
    private readonly LivroController _livroController;


    private Program()
    {
        _livroController = new LivroController();
    }

    private static void Main(string[] args)
    {
        var program = new Program();
        program._livroController.Iniciar();

    }
}


