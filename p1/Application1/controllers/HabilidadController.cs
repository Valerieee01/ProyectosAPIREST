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

    [HttpGet("[habilidadId]")]
    public ActionResult<Habilidad> GetHabilitiesById(int mandrilId, int habilityId)
    {
        var mandril = MandrilDataStorage.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

        if (mandril == null)
        {
            return NotFound("El Mnadril Solicitado no existe.");
        }

        var habilidad = mandril.Habilidades?.FirstOrDefault(h => h.Id == habilityId);
        if (habilidad == null)
        {
            return NotFound("El Mnadril Solicitado no existe.");
        }
        return Ok(habilidad);
    }

    // [HttpPost]
    // public ActionResult<Habilidad> PostHability()
    // {

    // }

    // [HttpPut]
    // public ActionResult<Habilidad> PutHability([FromRoute] int habilityId, [FromBody])
    // {

    // }

    // [HttpDelete]
    // public ActionResult<Habilidad> DeleteHability()
    // {
    // }
}