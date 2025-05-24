using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practica3.Servicios;
using Microsoft.AspNetCore.Authorization;
using practica3.Models;

namespace practica3.Controladores;

public class NoticiasController : Controller
{
    private readonly IServicioJsonPlaceholder _servicioNoticias;
    private readonly ServicioFeedback _servicioFeedback;

    public NoticiasController(IServicioJsonPlaceholder servicioNoticias, ServicioFeedback servicioFeedback)
    {
        _servicioNoticias = servicioNoticias;
        _servicioFeedback = servicioFeedback;
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EnviarFeedback(int publicacionId, string sentimiento)
    {
         Console.WriteLine("EnviarFeedback invocado correctamente");

         
        var usuario = User.Identity?.Name;
        var feedback = new FeedbackModelo
        {
            PublicacionId = publicacionId,
            Sentimiento = sentimiento,
            Fecha = DateTime.UtcNow,
            Usuario = usuario
        };

        var exito = await _servicioFeedback.EnviarFeedbackAsync(feedback);
        if (!exito)
        {
            TempData["Error"] = "No se pudo enviar el feedback: no autenticado o ya enviado.";
        }
        else
        {
            TempData["Mensaje"] = "Feedback enviado con éxito.";
        }

        return RedirectToAction("Detalles", new { id = publicacionId });
    }


}
