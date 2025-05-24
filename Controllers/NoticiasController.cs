using Microsoft.AspNetCore.Mvc;
using practica3.Servicios;
using practica3.Models;

namespace practica3.Controladores;

public class NoticiasController : Controller
{
    private readonly IServicioJsonPlaceholder _servicioNoticias;

    public NoticiasController(IServicioJsonPlaceholder servicioNoticias)
    {
        _servicioNoticias = servicioNoticias;
    }

    public async Task<IActionResult> Index()
    {
        var publicaciones = await _servicioNoticias.ObtenerPublicacionesAsync();
        return View(publicaciones);
    }

    public async Task<IActionResult> Detalles(int id)
    {
        var publicacion = await _servicioNoticias.ObtenerPublicacionPorIdAsync(id);
        if (publicacion == null) return NotFound();
        return View(publicacion);
    }
}
