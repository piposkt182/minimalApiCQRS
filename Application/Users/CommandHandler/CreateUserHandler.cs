
using Application.Abstractions;
using Application.Users.Commands;
using Domain.Models;
using MediatR;

namespace Application.Users.CommandHandler
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.CreateUser(request.User);
        }
    }
}
