using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practica3.Data;
using practica3.Models;

namespace practica3.Rest
{
    
    [ApiController]
    [Route("api/feedback")]
    public class FeedbackApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FeedbackApiController(ApplicationDbContext context)
        {
            _context = context;
            Console.WriteLine(">>> FeedbackApiController instanciado <<<");
        }

        // GET: api/feedback
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackModelo>>> GetFeedbacks()
        {
            return await _context.Feedbacks.ToListAsync();
        }

        // POST: api/feedback
        [HttpPost]
        public async Task<IActionResult> PostFeedback([FromBody] FeedbackModelo feedback)
        {
            Console.WriteLine(">>> PostFeedback llamado <<<");
            if (!ModelState.IsValid)
            {
                Console.WriteLine(">>> Modelo inválido <<<");
                foreach (var key in ModelState.Keys)
                {
                    var errors = ModelState[key]?.Errors;
                    if (errors != null)
                    {
                        foreach (var error in errors)
                        {
                            Console.WriteLine($"Error en {key}: {error.ErrorMessage}");
                        }
                    }
                }

                return BadRequest("Modelo inválido.");
            }

            // Si el modelo es válido, lo agregamos a la base de datos
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFeedbacks), new { id = feedback.Id }, feedback);
        }

}}
