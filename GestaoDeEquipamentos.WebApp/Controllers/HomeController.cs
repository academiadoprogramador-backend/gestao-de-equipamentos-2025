using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Controllers;

public class HomeController : Controller
{
    // Ação
    public IActionResult Index()
    {
        return View();
    }
}