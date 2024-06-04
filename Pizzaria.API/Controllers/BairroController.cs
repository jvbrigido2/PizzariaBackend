using Microsoft.AspNetCore.Mvc;
using Pizzaria.API.Contracts;
using Pizzaria.API.Domain;
using Pizzaria.API.Repositories.Interface;

namespace Pizzaria.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BairroController : ControllerBase
{
    private readonly IBairroRepository _repository;

    public BairroController(IBairroRepository repository)
    {
        _repository = repository;
    }
  
    [HttpGet("todos")]
    public async Task<ActionResult> GetAllBairros()
    {

        var bairros = await _repository.GetBairrosAsync();

        if (bairros is null)
        {
            return NotFound("Nenhum bairro cadastrado");
        }

        var response = new List<BairroResponse>();

        foreach (var bairro in bairros)
        {
            response.Add(new BairroResponse(bairro));
           
        }

        return Ok(response);

    }

    [HttpPost("criar-bairro")]
    public async Task<ActionResult> CreateBairro([FromBody] CreateBairroRequest request)
    {

        if (request == null || string.IsNullOrEmpty(request.Name))
        {
            return BadRequest("Nome do bairro não pode ser nulo ou vazio.");
        }

        var bairro = new Bairro
        {
            Name = request.Name,
            Value = request.Value,
            CreatedAt = DateTime.UtcNow,
        };

        var result = await _repository.CreateBairroAsync(bairro);

        if (result is null)
        {
            return Conflict("Bairro com esse nome ja existe");
        }

        var response = new BairroResponse(bairro);
      
        return Ok(response);
    }

    [HttpGet("nome")]
    public async Task<ActionResult> GetByName([FromQuery] string name)
    {
        var bairro = await _repository.GetBairroByNameAsync(name);

        if(bairro is null)
        {
            return NotFound("Bairro nao encontrado");
        }

        var response = new BairroResponse(bairro);

        return Ok(response);
    }

    [HttpDelete("deletar/{id}")]
    public async Task<ActionResult> DeleteBairro([FromRoute] long id)
    {
        var bairro = await _repository.DeleteBairroAsync(id);

        if(bairro is null)
        {
            return NotFound("Bairro nao encontrado");
        }

        return NoContent();
    }

    [HttpPut("atualizar/{id}")]
    public async Task<ActionResult> UpdateBairro([FromBody] UpdateBairroRequest request, [FromRoute] long id)
    {
        var bairro = new Bairro
        {
            Id = id,
            Name = request.Name,
            Value = request.Value,
        };

        var result = await _repository.UpdateBairroAsync(id, bairro);

        if(result is null)
        {
            return NotFound("Bairro nao encontrado");
        }

        var response = new BairroResponse(result);
      
        return Ok(response);
    }
}
