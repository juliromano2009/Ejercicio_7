using Microsoft.AspNetCore.Mvc;
using TurnosPeluqueria_EJ06.Models;

namespace TurnosPeluqueria_EJ06.Controllers;

public class TurnosController : Controller
{
    private BD bd = new BD();

    public IActionResult Index()
    {
        ViewBag.turnos = bd.ObtenerTurnos();
        return View();
    }

    [HttpGet]
    public IActionResult Nuevo()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Nuevo(Turno turno)
    {
        if (turno.Estado == null || turno.Estado == "")
        {
            turno.Estado = "Pendiente";
        }

        bd.AgregarTurno(turno);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Atender(int id)
    {
        bd.CambiarEstado(id, "Atendido");
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Cancelar(int id)
    {
        bd.CambiarEstado(id, "Cancelado");
        return RedirectToAction("Index");
    }
    
}