using BiteFightRevival.Domain.Interfaces;
using MediatR;

namespace BiteFightRevival.Application.Character.UseCases.CreateCharacter;

public class CreateCharacterHandler(ICharacterRepository characterRepository) : IRequestHandler<CreateCharacterCommand, Guid>
{
    public async Task<Guid> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
    {
        var characterNameExists = await characterRepository
            .GetByNameAsync(request.Name, cancellationToken);

        if (characterNameExists is null) 
            throw new Exception("Character name is already taken.");

        var character = new Domain.Entities.Character
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Race = request.Race,
            UserId = request.UserId
        };
        
        await characterRepository.CreateAsync(character, cancellationToken);
        return character.Id;
    }
}