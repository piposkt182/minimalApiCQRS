using Domain.Models;
using MediatR;

namespace Application.Users.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public int Dni { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty;
        public int GenderId { get; set; }

        public string Street { get; set; } = string.Empty;
        public string CountryId { get; set; } 
        public string ZipCode { get; set; } = string.Empty;
    }
}
