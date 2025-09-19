using Domain.Models;
using MediatR;

namespace Application.Users.Queries
{
    public class GetAllUserQuery :IRequest<ICollection<User>>
    {
    }
}
