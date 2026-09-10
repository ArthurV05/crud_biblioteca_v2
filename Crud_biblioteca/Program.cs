using Crud_biblioteca.Controllers;

internal class Program
{
    private readonly LivroController _livroController;

    private Program()
    {
        _livroController = new LivroController();
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
