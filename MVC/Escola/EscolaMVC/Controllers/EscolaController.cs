using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EscolaMVC.Models;

namespace EscolaMVC.Controllers;

public class EscolaController : Controller
{
    private readonly ILogger<EscolaController> _logger;

    public EscolaController(ILogger<EscolaController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Adicionar()
    {
        return View();
    }
    public IActionResult Editar()
    {
        return View();
    }
    public IActionResult Deletar()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
