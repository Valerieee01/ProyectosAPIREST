using Application1.helpers;
using Application1.models;
using Application1.services;
using Microsoft.AspNetCore.Mvc;

namespace Application1.controllers;

[ApiController]
[Route("/api/[controller]")]
public class MandrilController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Mandrils>> GetMandriles()
    {
        return MandrilDataStorage.Current.Mandriles;
    }

    [HttpGet("{mandrilId}")]
    public ActionResult<Mandrils> GetMandril(int mandrilId)
    {
        var mandril = MandrilDataStorage.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);
        }
        return Ok(mandril);
    }

    [HttpGet("apellido/{ApellidoMandril}")]
    public ActionResult<Mandrils> GetHabilidadesMandril(String ApellidoMandril)
    {
        var mandril = MandrilDataStorage.Current.Mandriles.FirstOrDefault(x => x.Apelido == ApellidoMandril);

        if (mandril == null)
        {
            return NotFound("No existe ningun mandril con apellido " + ApellidoMandril + ". ");
        }
        return Ok(mandril);
    }

    [HttpPost]
    public ActionResult<Mandrils> PostMandril(MandrilsInsert mandrilsInsert)
    {
        var maxMandrilId = MandrilDataStorage.Current.Mandriles.Max(X => X.Id);

        var mandrilNuevo = new Mandrils()
        {
            Id = maxMandrilId + 1,
            Nombre = mandrilsInsert.Nombre,
            Apelido = mandrilsInsert.Apelido
        };

        MandrilDataStorage.Current.Mandriles.Add(mandrilNuevo);

        return CreatedAtAction(nameof(GetMandril),
            new { mandrilId = mandrilNuevo.Id },
            mandrilNuevo
        );
    }

    [HttpPut("{mandrilId}")]
    public ActionResult<Mandrils> PutMandril([FromRoute] int mandrilId, [FromBody] MandrilsInsert mandrilsInsert)
    {
        var mandril = MandrilDataStorage.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);
        }

        mandril.Nombre = mandrilsInsert.Nombre;
        mandril.Apelido = mandrilsInsert.Apelido;

        return NoContent();

    }

    [HttpDelete("{mandrilId}")]
    public ActionResult<Mandrils> DeleteMandril(int mandrilId)
    {

        var mandril = MandrilDataStorage.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);
        }

        MandrilDataStorage.Current.Mandriles.Remove(mandril);

        return NoContent();
    }

}