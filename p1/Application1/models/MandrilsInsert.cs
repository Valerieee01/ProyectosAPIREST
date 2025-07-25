using System.ComponentModel.DataAnnotations;

namespace Application1.models;

public class MandrilsInsert
{
    [Required]
    [MaxLength(50)]
    public string Nombre { get; set; } = string.Empty;


    [Required]
    [MaxLength(50)]
    public string Apelido { get; set; } = string.Empty;
}
