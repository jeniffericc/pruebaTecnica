using Microsoft.EntityFrameworkCore;
using PruebaTecnica.BusinessLogic.Interfaces;
using PruebaTecnica.BusinessLogic.Services;
using PruebaTecnica.Domain.Interfaces;
using PruebaTecnica.Infrastructure.Data;
using PruebaTecnica.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IBankAccountService, BankAccountService>();
builder.Services.AddScoped<IBankAccountRepository, BankAccountRepository>();

builder.Services.AddScoped<ITransactionTypeService, TransactionTypeService>();
builder.Services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();

builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddDbContext<PruebaTecnicaDbContext>(options =>
   options.UseSqlite(builder.Configuration.GetConnectionString("PruebaTecnicaDB")));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.UseAuthorization();
app.MapControllers();
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
