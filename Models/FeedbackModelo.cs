using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using practica3.Models;

namespace practica3.Models;

[Table("t_feedback")]
public class FeedbackModelo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int PublicacionId { get; set; }

    [Required]
    [MaxLength(10)]
    public string Sentimiento { get; set; } = "like"; // "like" o "dislike"

    [Required]
    public DateTime Fecha { get; set; }
}

