using Microsoft.AspNetCore.Mvc;
using Zoo.Application.Handlers.Cuidado;
using Zoo.Application.Handlers.Cuidado.Requests;

namespace Zoo.Api.Controllers;

[ApiController]
[Route("api/cuidados")]
public class CuidadosController : ControllerBase
{
    private readonly CuidadoHandler _cuidadoHandler;

    public CuidadosController(CuidadoHandler cuidadoHandler)
    {
        _cuidadoHandler = cuidadoHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _cuidadoHandler.GetAllAsync();
        return Ok(list);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var dto = await _cuidadoHandler.GetByIdAsync(id);
        return dto == null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCuidadoRequest request)
    {
        try
        {
            var created = await _cuidadoHandler.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCuidadoRequest request)
    {
        if (id != request.Id) return BadRequest();
        var ok = await _cuidadoHandler.UpdateAsync(request);
        return ok ? NoContent() : NotFound();
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var ok = await _cuidadoHandler.DeleteAsync(id);
        return ok ? NoContent() : NotFound();
    }
}