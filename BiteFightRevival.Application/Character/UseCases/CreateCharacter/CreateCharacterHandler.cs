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

        var character = Domain.Entities.Character.Create(request.Name, request.Race, request.UserId);
        
        await characterRepository.CreateAsync(character, cancellationToken);
        return character.Id;
    }
}