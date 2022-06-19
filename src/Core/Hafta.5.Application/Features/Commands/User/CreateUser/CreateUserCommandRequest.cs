using MediatR;


namespace Hafta._5.Application.Features.Commands.User.CreateUser
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
