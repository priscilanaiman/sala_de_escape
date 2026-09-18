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
        BD bd = new BD();
        bd.CrearParticipante(nombre);
        HttpContext.Session.SetString("NombreJugador", nombre);
        int idPartida = bd.CrearPartida(bd.ObtenerIdParticipante(nombre));
        HttpContext.Session.SetString("IdPartida", idPartida.ToString());
        HttpContext.Session.SetString("SalaActual", "1");
        return RedirectToAction("Sala", new { sala = 1 });
    }
    //crear accion Sala que reciba un parametro sala y lo guarde en la session
    public IActionResult Sala(int sala)
    {
        BD bd = new BD();
        HttpContext.Session.SetString("SalaActual", sala.ToString());
        int idPartida = int.Parse(HttpContext.Session.GetString("IdPartida"));
        bd.actualizarSalaActual(idPartida, sala);
        return View("sala" + sala);
    }
    //FinalizarPartida llevando a una view de final
    public IActionResult FinalizarPartida()
    {
        //obtener el id de la partida de la session
        int idPartida = int.Parse(HttpContext.Session.GetString("IdPartida"));
        //actualizar la partida en la base de datos con la fecha de fin y el estado
        BD bd = new BD();
        bd.FinalizarPartida(idPartida);
        return View("Final");
    }
    public IActionResult Expediente(int numeroExpediente)
    {
        Console.WriteLine("Número de expediente: " + numeroExpediente);
        return View("Expediente" + numeroExpediente);
    }
    public IActionResult RetomarPartida()
    {
        //ingresar nombre y en base a eso buscar la partida en la base de datos y cargar la sala actual
        return View("IngresarNombreRetomar");
    }
    public IActionResult Retomar(string nombre)
    {
        BD bd = new BD();
        int idPartida = bd.ObtenerIdUltimaPartida(nombre);
        if (idPartida == 0)
        {
            ViewBag.Mensaje = "No se encontró ninguna partida para el jugador " + nombre;
            return View("Index");
        }
        else
        {
            //si existe la partida, cargar la sala actual y redirigir a la sala correspondiente
            HttpContext.Session.SetString("NombreJugador", nombre);
            HttpContext.Session.SetString("IdPartida", idPartida.ToString());
            int salaActual = bd.ObtenerSalaActual(idPartida);
            HttpContext.Session.SetString("SalaActual", salaActual.ToString());
            return RedirectToAction("Sala", new { sala = salaActual });
        }
    }
}

