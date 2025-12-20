using BiteFightRevival.Application.Character.UseCases.CreateCharacter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiteFightRevival.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharactersController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCharacter(CreateCharacterCommand command)
    {
        var result = await mediator.Send(command);
        return CreatedAtAction(nameof(CreateCharacter), new { id = result }, result);
    }
}