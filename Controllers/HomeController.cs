using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using sala_de_escape.Models;

namespace sala_de_escape.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    //controller que vaya a la vista de tutorial. otro a ingresar nombre y otro a la story

    public IActionResult Tutorial()
    {
        return View();
    }

    public IActionResult IngresarNombre()
    {
        return View();
    }

    public IActionResult Story()
    {
        return View();
    }
    //controler ComenzarSalas que guarde en la session el nombre del jugador, la sala actual y el id de la partida
    public IActionResult ComenzarSalas(string nombre)
    {
        HttpContext.Session.SetString("NombreJugador", nombre);
        //generar un id en la base de datos para la partida y guardarlo en la session
        BD bd = new BD();
        int idPartida = bd.CrearPartida(nombre);
        HttpContext.Session.SetString("IdPartida", idPartida.ToString());
        HttpContext.Session.SetString("SalaActual", "1");
        return RedirectToAction("Sala", new { sala = sala });
    }

}

