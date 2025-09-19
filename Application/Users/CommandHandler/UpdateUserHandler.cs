using Application.Abstractions;
using Application.Users.Commands;
using Domain.Models;
using MediatR;

namespace Application.Users.CommandHandler
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.UpdateUser(request.User);
        }
    }
}
