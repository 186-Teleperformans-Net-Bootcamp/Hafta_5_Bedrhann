using Hafta._5.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Hafta._5.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private UserManager<AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult identityResult = await _userManager.CreateAsync(new AppUser()
            {
                UserName = request.UserName,
                Nickname = request.NickName,
                City = request.City,
                Age = request.Age,
                Email = request.Email
            }, request.Password);

            if (identityResult.Succeeded)
            {
                return new CreateUserCommandResponse()
                {
                    Succeeded = true,
                    Message = "User Created"
                };
            }
            throw new NotImplementedException();

        }
    }
}
