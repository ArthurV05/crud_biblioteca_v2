using Crud_biblioteca.Controllers;
using Crud_biblioteca.Services;
using Crud_biblioteca.Repositories;

internal class Program
{
    private readonly LivroController _livroController;

    private Program()
    {
        ILivroRepository repository = new LivroRepository();
        ILivroService service = new LivroService(repository);

        _livroController = new(service);

    }
    private static void Main(string[] args)
    {
        try
        {
            var program = new Program();
            program._livroController.Iniciar();
        } 
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Não foi possível continuar: {ex.Message}");
        }
    }
}
