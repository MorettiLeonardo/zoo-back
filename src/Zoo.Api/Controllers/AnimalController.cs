using Microsoft.AspNetCore.Mvc;
using Zoo.Application.Handlers.Animal;
using Zoo.Application.Handlers.Animal.Requests;

namespace Zoo.Api.Controllers;

[ApiController]
[Route("api/animal")]
public class AnimalsController : ControllerBase
{
    private readonly AnimalHandler _animalHandler;

    public AnimalsController(AnimalHandler animalHandler)
    {
        _animalHandler = animalHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _animalHandler.GetAllAsync();
        return Ok(list);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var dto = await _animalHandler.GetByIdAsync(id);
        return dto == null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAnimalRequest request)
    {
        try
        {
            var created = await _animalHandler.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAnimalRequest request)
    {
        if (id != request.Id) return BadRequest();
        var ok = await _animalHandler.UpdateAsync(request);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var ok = await _animalHandler.DeleteAsync(id);
        return ok ? NoContent() : NotFound();
    }
}