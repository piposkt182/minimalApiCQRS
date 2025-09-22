using MinimalApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServices();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});


var app = builder.Build();

app.Use(async (ctx, next) =>
{
    try
    {
        await next();
    }
    catch (Exception ex)
    {
        ctx.Response.StatusCode = 500;
        await ctx.Response.WriteAsync("An error acurred");
    }
});

app.UseHttpsRedirection();

app.RegisterEndpointDefinitions();
app.RegisterUserEndpointDefinitions();

app.Run();
