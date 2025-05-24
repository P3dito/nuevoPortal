using practica3.Models;

namespace practica3.Servicios;

public interface IServicioJsonPlaceholder
{
    Task<List<PublicacionVistaModelo>> ObtenerPublicacionesAsync();
    Task<PublicacionVistaModelo?> ObtenerPublicacionPorIdAsync(int id);
}
