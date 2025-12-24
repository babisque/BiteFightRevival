using MediatR;

namespace BiteFightRevival.Application.Auth.UseCases.Register;

public record RegisterCommand(string Email, string Password, string PlayerName, DateTime BirthDate) : IRequest<Guid>;