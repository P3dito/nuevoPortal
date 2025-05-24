using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using practica3.Models;

namespace practica3.Models;

[Table("t_publicacion")]
public class PublicacionVistaModelo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Titulo { get; set; }

    [Required]
    public string Cuerpo { get; set; }

    [Required]
    public int AutorId { get; set; }

    [ForeignKey("AutorId")]
    public AutorVistaModelo? Autor { get; set; }

    public ICollection<ComentarioVistaModelo>? Comentarios { get; set; }
}
