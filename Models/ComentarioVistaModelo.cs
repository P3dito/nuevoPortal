using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using practica3.Models;

namespace practica3.Models;

[Table("t_comentario")]
public class ComentarioVistaModelo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; }

    [Required]
    [EmailAddress]
    public string Correo { get; set; }

    [Required]
    public string Cuerpo { get; set; }

    [Required]
    public int PublicacionId { get; set; }

    [ForeignKey("PublicacionId")]
    public PublicacionVistaModelo? Publicacion { get; set; }
}
