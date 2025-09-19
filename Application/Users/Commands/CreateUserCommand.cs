using Domain.Models;
using MediatR;

namespace Application.Users.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public User User { get; set; }
    }
}
