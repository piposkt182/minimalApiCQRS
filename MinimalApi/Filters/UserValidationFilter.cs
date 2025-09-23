using MinimalApi.Dto;

namespace MinimalApi.Filters
{
    public class UserValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var user = context.GetArgument<CreateUserDto>(1);
            if (string.IsNullOrEmpty(user.Name)) return await Task.FromResult(Results.BadRequest("name user is required"));
            if (string.IsNullOrEmpty(user.LastName)) return await Task.FromResult(Results.BadRequest("last name user is required"));
            if (string.IsNullOrEmpty(user.Address.Street)) return await Task.FromResult(Results.BadRequest("Street address is required"));
            if (string.IsNullOrEmpty(user.Address.ZipCode)) return await Task.FromResult(Results.BadRequest("Street address is required"));
            if (string.IsNullOrEmpty(user.Address.CountryId)) return await Task.FromResult(Results.BadRequest("Country address is required"));

            return await next(context);
        }
    }
}
