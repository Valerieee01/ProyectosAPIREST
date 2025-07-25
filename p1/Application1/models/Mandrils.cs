namespace Application1.models;

public class Mandrils
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Apelido { get; set; } = string.Empty;

    public List<Habilidad>? Habilidades { get; set; }

}