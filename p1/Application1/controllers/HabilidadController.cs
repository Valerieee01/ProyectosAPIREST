using Application1.helpers;
using Application1.models;
using Application1.services;
using Microsoft.AspNetCore.Mvc;

namespace Application1.controllers;

[ApiController]
[Route("api/mandril/{mandrilId}/[controller]")]
public class HabilidadController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Habilidad>> GetHabilities(int mandrilId)
    {
         var mandril = MandrilDataStorage.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);
        }

        return Ok(mandril.Habilidades);
    }

    [HttpGet("{habilidadId}")]
     public ActionResult<Habilidad> GetHabilitiesById(int mandrilId, int habilidadId)
     {
         var mandril = MandrilDataStorage.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

         if (mandril == null)
         {
             return NotFound(Mensajes.Mandril.NotFound);
         }

         var habilidad = mandril.Habilidades?.FirstOrDefault(h => h.Id == habilidadId);
         if (habilidad == null)
         {
             return NotFound(Mensajes.Habilidad.NotFound);
         }
         return Ok(habilidad);
     }

    [HttpPost]
    public ActionResult<Habilidad> PostHability(int mandrilId, HabilidadInsert habilidadInsert)
    {
        var mandril = MandrilDataStorage.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);
        }

        var habilidadExistente = mandril.Habilidades?.FirstOrDefault(h => h.Nombre == habilidadInsert.Nombre);

        if (habilidadExistente != null)
        {
            return BadRequest("Ya existe una habilidad con este");
        }

        var maxHabilidad = mandril.Habilidades.Max(h => h.Id);

        var habilidadNueva = new Habilidad()
        {
            Id = maxHabilidad + 1,
            Nombre = habilidadInsert.Nombre,
            Potencia = habilidadInsert.Potencia
        };

        mandril.Habilidades.Add(habilidadNueva);

        return CreatedAtAction(nameof(GetHabilitiesById), 
            new { mandrilId = mandrilId, habilidadId = habilidadNueva.Id},
            habilidadNueva
        );
     }

     [HttpPut]
     public ActionResult<Habilidad> PutHabilidad ( int habilidadId, int mandrilId, HabilidadInsert habilidadInsert)
     {
        var mandril = MandrilDataStorage.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);
        }

        var habilidadExistente = mandril.Habilidades?
        .FirstOrDefault(h => h.Id == habilidadId);

        if (habilidadExistente == null)
        {
            return BadRequest(Mensajes.Habilidad.NotFound);
        }

        var habilidadMismoNombre = mandril.Habilidades?
        .FirstOrDefault(H => H.Id != habilidadId && H.Nombre == habilidadInsert.Nombre);

        if (habilidadMismoNombre != null)
        {
            return BadRequest(Mensajes.Habilidad.NombreExistente);
        }

        habilidadExistente.Nombre = habilidadInsert.Nombre;
        habilidadExistente.Potencia = habilidadInsert.Potencia;

        return NoContent();
     }

    [HttpDelete]
    public ActionResult<Habilidad> DeleteHabilidad(int habilidadId, int mandrilId)
    {
        var mandril = MandrilDataStorage.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);
        }

        var habilidadExistente = mandril.Habilidades?.FirstOrDefault(h => h.Id == habilidadId);

        if (habilidadExistente != null)
        {
            return BadRequest(Mensajes.Habilidad.NotFound);
        }


        mandril.Habilidades?.Remove(habilidadExistente);

        return NoContent();
     }
}