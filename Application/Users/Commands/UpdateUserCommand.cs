using Domain.Models;
using MediatR;

namespace Application.Users.Commands
{
    public class UpdateUserCommand : IRequest<User>
    {
        public User User { get; set; }
    }
}
