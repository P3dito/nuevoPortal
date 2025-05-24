using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using practica3.Models;
using Microsoft.AspNetCore.Authentication;
using practica3.Rest;

namespace practica3.Servicios
{
    public class ServicioFeedback
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ServicioFeedback(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> EnviarFeedbackAsync(FeedbackModelo feedback)
        {
            
            var json = JsonSerializer.Serialize(feedback);
            Console.WriteLine($"JSON a enviar: {json}");
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/feedback", content);
            return response.IsSuccessStatusCode;
        }
    }
}
