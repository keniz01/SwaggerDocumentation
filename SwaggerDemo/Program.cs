using SwaggerDocumentation.SwaggerDemo.Middleware;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddControllers();

// Required by Swagger to avoid "Unable to resolve service
// for type 'Microsoft.AspNetCore.Mvc.ApiExplorer.IApiDescriptionGroupCollectionProvider'"
services.AddEndpointsApiExplorer();

// Swagger middleware extension.
services.AddSwaggerMiddleware();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Swagger middleware extension.
    app.UseSwaggerMiddleware();
}

app.MapControllers();
app.Run();
