using BiteFightRevival.Domain.Enums;
using MediatR;

namespace BiteFightRevival.Application.Character.UseCases.CreateCharacter;

public record CreateCharacterCommand(string Name, Race Race, Guid UserId) : IRequest<Guid>;