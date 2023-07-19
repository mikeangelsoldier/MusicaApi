using MusicaApi.Models;
using MusicaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MusicaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CancionController : ControllerBase
{
    private readonly CancionService _cancionService;

    public CancionController(CancionService cancionService) =>
        _cancionService = cancionService;

    [HttpGet]
    public async Task<List<Cancion>> Get() =>
        await _cancionService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Cancion>> Get(string id)
    {
        var cancion = await _cancionService.GetAsync(id);

        if (cancion is null)
        {
            return NotFound();
        }

        return cancion;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Cancion newCancion)
    {
        await _cancionService.CreateAsync(newCancion);

        return CreatedAtAction(nameof(Get), new { id = newCancion.Id }, newCancion);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Cancion updatedCancion)
    {
        var cancion = await _cancionService.GetAsync(id);

        if (cancion is null)
        {
            return NotFound();
        }

        updatedCancion.Id = cancion.Id;

        await _cancionService.UpdateAsync(id, updatedCancion);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var cancion = await _cancionService.GetAsync(id);

        if (cancion is null)
        {
            return NotFound();
        }

        await _cancionService.RemoveAsync(id);

        return NoContent();
    }
}