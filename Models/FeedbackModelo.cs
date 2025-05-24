namespace practica3.Modelos;

public class FeedbackModelo
{
    public int PublicacionId { get; set; }
    public string Sentimiento { get; set; } // "like" o "dislike"
    public DateTime Fecha { get; set; }
}
