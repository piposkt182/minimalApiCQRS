using Application.Users.Commands;
using Application.Users.Queries;
using Domain.Models;
using MediatR;
using MinimalApi.Abstractions;
using MinimalApi.Dto;

namespace MinimalApi.EndpointDefinitions
{
    public class UserEndpointDefinition : IUserEndpointDefinition
    {
        public void RegisterUserEndpoint(WebApplication app)
        {

            var users = app.MapGroup("/api/users");

            users.MapGet("/", GetAllUsers);

            users.MapGet("/{id}", GetUserById);

            users.MapPost("/", CreateUser);

            users.MapPut("/", UpdateUser);

            users.MapDelete("/{id}", DeleteUser);
        }

        private async Task<IResult> GetAllUsers(IMediator mediator)
        {
            var query = new GetAllUserQuery();
            var users = await mediator.Send(query);
            return TypedResults.Ok(users);
        }

        private async Task<IResult> GetUserById(IMediator mediator, int id)
        {
            var query = new GetUserByIdQuery { Id = id};
            var user  = await mediator.Send(query);
            return TypedResults.Ok(user); 
        }

        private async Task<IResult> CreateUser(IMediator mediator, CreateUserDto dto)
        {
            var command = new CreateUserCommand {
                Dni = dto.Dni,
                Name = dto.Name,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                Email = dto.Email,
                GenderId = dto.GenderId,
                CountryId = dto.Address.CountryId,
                Street = dto.Address.Street,
                ZipCode = dto.Address.ZipCode
            };
            var userCreated = await mediator.Send(command);
            return TypedResults.Ok(userCreated);
        }

        private async Task<IResult> UpdateUser(IMediator mediator, User user)
        {
            var command = new UpdateUserCommand { User = user };
            var userUpdated = await mediator.Send(command);
            return TypedResults.Ok(userUpdated);
        }

        private async Task<IResult> DeleteUser(IMediator mediator, int id)
        {
            var command = new DeleteUserCommand { Id = id };
            await mediator.Send(command);   
            return TypedResults.NoContent();    
        } 
    }
}
