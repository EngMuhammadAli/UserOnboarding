using UserOnboarding.Infrastructure.DI;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Get connection string from appsettings.json
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register infrastructure DI container
builder.Services.AddInfrastructure(connectionString);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
