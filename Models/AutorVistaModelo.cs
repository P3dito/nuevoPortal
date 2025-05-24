using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using practica3.Models;

namespace practica3.Models;

[Table("t_autor")]
public class AutorVistaModelo
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; }

    [Required]
    [EmailAddress]
    public string Correo { get; set; }

    public ICollection<PublicacionVistaModelo>? Publicaciones { get; set; }
}
