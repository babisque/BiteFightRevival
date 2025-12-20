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
        await mediator.Send(command);
        return Ok();
    }
}