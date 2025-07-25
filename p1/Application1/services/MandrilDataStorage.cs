using Application1.models;

namespace Application1.services;

public class MandrilDataStorage
{
    public List<Mandrils> Mandriles { get; set; }

    public static MandrilDataStorage Current { get; } = new MandrilDataStorage();

    public MandrilDataStorage()
    {
        Mandriles = new List<Mandrils>()
        {
          new Mandrils() {
            Id = 1,
            Nombre = "Mini Mandril",
            Apelido = "Rodriguez",
            Habilidades = new List<Habilidad>() {
                new Habilidad() {
                    Id = 1,
                    Nombre = "Saltar",
                    Potencia =  Habilidad.EPotencia.Moderado
                }
            }
          },
          new Mandrils() {
            Id = 2,
            Nombre = "Nano Mandril",
            Apelido = "Lucre",
            Habilidades = new List<Habilidad>() {
                new Habilidad() {
                    Id = 1,
                    Nombre = "Saltar",
                    Potencia =  Habilidad.EPotencia.Moderado
                },
                 new Habilidad() {
                    Id = 2,
                    Nombre = "Correr",
                    Potencia =  Habilidad.EPotencia.Extremo
                },
                 new Habilidad() {
                    Id = 3,
                    Nombre = "Nadar",
                    Potencia =  Habilidad.EPotencia.Intenso
                }
            }
          },

          new Mandrils() {
            Id = 3,
            Nombre = "Ultra Mandril",
            Apelido = "Roa",
            Habilidades = new List<Habilidad>() {
                new Habilidad() {
                    Id = 6,
                    Nombre = "Esconderse",
                    Potencia =  Habilidad.EPotencia.Seave
                },
                  new Habilidad() {
                    Id = 7,
                    Nombre = "Dormir",
                    Potencia =  Habilidad.EPotencia.Moderado
                },
                  new Habilidad() {
                    Id = 8,
                    Nombre = "Golpear",
                    Potencia =  Habilidad.EPotencia.RePotente
                }
            }
          },
          new Mandrils() {
            Id = 4,
            Nombre = "Sotra Mandril",
            Apelido = "Redril",
            Habilidades = new List<Habilidad>() {
                new Habilidad() {
                    Id = 9,
                    Nombre = "Romper",
                    Potencia =  Habilidad.EPotencia.RePotente
                }
            }
          },
        };
    }
}