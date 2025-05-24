namespace practica3.Modelos;

public class PublicacionVistaModelo
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Cuerpo { get; set; }
    public AutorVistaModelo Autor { get; set; }
    public List<ComentarioVistaModelo> Comentarios { get; set; }
}