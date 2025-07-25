using static Application1.models.Habilidad; 
using System.ComponentModel.DataAnnotations;

namespace Application1.models;

public class HabilidadInsert
{
    [Required]
    [MaxLength(50)]
    public string Nombre { get; set; } = string.Empty;

    public EPotencia Potencia { get; set; }

}
