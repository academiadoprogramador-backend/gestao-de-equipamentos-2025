namespace GestaoDeEquipamentos.WebApp;

internal class Program
{
    static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews(); // ASP.NET MVC - Model View Controller

        WebApplication app = builder.Build();

        app.UseRouting();
        app.MapDefaultControllerRoute();

        app.Run();
    }
}
