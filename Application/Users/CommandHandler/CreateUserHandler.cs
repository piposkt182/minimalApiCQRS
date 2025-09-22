
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
            var user = new User
            {
                Dni = request.Dni,
                Name = request.Name,
                lastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Email = request.Email,
                GenderId = request.GenderId,
                Address = new Address {
                   Street= request.Street, 
                   ZipCode =  request.ZipCode,
                   CountryId =  request.CountryId}
            };
            return await _userRepository.CreateUser(user);
        }
    }
}
