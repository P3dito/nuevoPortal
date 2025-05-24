using practica3.Models;
using System.Net.Http.Json;

namespace practica3.Servicios;

public class ServicioJsonPlaceholder : IServicioJsonPlaceholder
{
    private readonly HttpClient _httpClient;

    public ServicioJsonPlaceholder(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<PublicacionVistaModelo>> ObtenerPublicacionesAsync()
    {
        var publicaciones = await _httpClient.GetFromJsonAsync<List<PostJson>>("posts");
        var autores = await _httpClient.GetFromJsonAsync<List<UsuarioJson>>("users");

        var publicacionesEnriquecidas = publicaciones.Select(p =>
        {
            var autor = autores.FirstOrDefault(a => a.Id == p.UserId);
            return new PublicacionVistaModelo
            {
                Id = p.Id,
                Titulo = p.Title,
                Cuerpo = p.Body,
                Autor = new AutorVistaModelo
                {
                    Id = autor?.Id ?? 0,
                    Nombre = autor?.Name ?? "Desconocido",
                    Correo = autor?.Email ?? "sin-email"
                },
                Comentarios = new List<ComentarioVistaModelo>() // se carga en método Detalles
            };
        }).ToList();

        return publicacionesEnriquecidas;
    }

    public async Task<PublicacionVistaModelo?> ObtenerPublicacionPorIdAsync(int id)
    {
        var post = await _httpClient.GetFromJsonAsync<PostJson>($"posts/{id}");
        if (post == null) return null;

        var autor = await _httpClient.GetFromJsonAsync<UsuarioJson>($"users/{post.UserId}");
        var comentarios = await _httpClient.GetFromJsonAsync<List<ComentarioJson>>($"comments?postId={id}");

        return new PublicacionVistaModelo
        {
            Id = post.Id,
            Titulo = post.Title,
            Cuerpo = post.Body,
            Autor = new AutorVistaModelo
            {
                Id = autor?.Id ?? 0,
                Nombre = autor?.Name ?? "Desconocido",
                Correo = autor?.Email ?? "sin-email"
            },
            Comentarios = comentarios.Select(c => new ComentarioVistaModelo
            {
                Nombre = c.Name,
                Correo = c.Email,
                Cuerpo = c.Body
            }).ToList()
        };
    }

    // Clases internas para deserialización
    private class PostJson
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    private class UsuarioJson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    private class ComentarioJson
    {
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
