using Application.Abstractions;
using Application.Users.Queries;
using Domain.Models;
using MediatR;

namespace Application.Users.QueryHandler
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, ICollection<User>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ICollection<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllUsers();
        }
    }
}
