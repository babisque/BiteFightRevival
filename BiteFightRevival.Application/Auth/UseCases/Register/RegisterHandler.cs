using BiteFightRevival.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BiteFightRevival.Application.Auth.UseCases.Register;

public class RegisterHandler(UserManager<ApplicationUser> userManager) : IRequestHandler<RegisterCommand, Guid>
{
    public async Task<Guid> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await userManager.FindByEmailAsync(request.Email);
        if (existingUser is not null) throw new Exception("User already exists");
        
        var newUser = new ApplicationUser
        {
            UserName = request.PlayerName,
            Email = request.Email,
            BirthDate =  request.BirthDate,
        };

        var result = await userManager.CreateAsync(newUser, request.Password);
        if (result.Succeeded) return newUser.Id;
        
        var errors = string.Join(", ", result.Errors.Select(e => e.Description));
        throw new Exception($"Registration failed: {errors}");

    }
}