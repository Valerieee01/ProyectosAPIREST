namespace Application1.models;
public class Habilidad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public EPotencia Potencia { get; set; }
    public enum EPotencia
    {
        Seave,
        Moderado,
        Intenso,
        RePotente,
        Extremo
    } 

}