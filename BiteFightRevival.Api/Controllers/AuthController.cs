using BiteFightRevival.Application.Auth.UseCases.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiteFightRevival.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand request)
    {
        var response = await mediator.Send(request);
        return CreatedAtAction(nameof(Register), new { Id = response }, response);
    }
}