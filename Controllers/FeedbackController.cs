using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using practica3.Data;
using practica3.Models;

namespace practica3.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeedbackController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> MisFeedbacks()
        {
            var usuario = User.Identity?.Name;

            if (string.IsNullOrEmpty(usuario))
            {
                return RedirectToAction("Login", "Account");
            }

            var feedbacks = await _context.Feedbacks
                .Where(f => f.Usuario == usuario)
                .OrderByDescending(f => f.Fecha)
                .ToListAsync();

            return View(feedbacks);
        }
    }
}
