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
            return NotFound("El Mnadril Solicitado no existe.");
        }

        return Ok(mandril.Habilidades);
    }

    [HttpGet("{habilidadId}")]
     public ActionResult<Habilidad> GetHabilitiesById(int mandrilId, int habilidadId)
     {
         var mandril = MandrilDataStorage.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

         if (mandril == null)
         {
             return NotFound("El Mandril Solicitado no existe.");
         }

         var habilidad = mandril.Habilidades?.FirstOrDefault(h => h.Id == habilidadId);
         if (habilidad == null)
         {
             return NotFound("Este Mandril no tiene la habilidad solicitada.");
         }
         return Ok(habilidad);
     }

    [HttpPost]
    public ActionResult<Habilidad> PostHability(int mandrilId, HabilidadInsert habilidadInsert)
    {
        var mandril = MandrilDataStorage.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

        if (mandril == null)
        {
            return NotFound("El Mandril Solicitado no existe.");
        }

        var habilidadExistente = mandril.Habilidades?.FirstOrDefault(h => h.Nombre == habilidadInsert.Nombre);

        if (habilidadExistente != null)
        {
            return BadRequest("Ya existe una habilidad con este");
        }

        var maxHabilidadId = mandril.Habilidades?.Max(h => h.Id);

        var habilidadNueva = new Habilidad()
        {
            Id = maxHabilidadId + 1,
            Nombre =  
        }
     }

    // [HttpPut]
    // public ActionResult<Habilidad> PutHability([FromRoute] int habilidadId, [FromBody])
    // {

    // }

    // [HttpDelete]
    // public ActionResult<Habilidad> DeleteHability()
    // {
    // }
}