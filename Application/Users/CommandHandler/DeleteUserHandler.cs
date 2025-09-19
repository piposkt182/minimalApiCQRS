
using Application.Abstractions;
using Application.Users.Commands;
using MediatR;

namespace Application.Users.CommandHandler
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteUser(request.Id);
            return Unit.Value;
        }
    }
}
