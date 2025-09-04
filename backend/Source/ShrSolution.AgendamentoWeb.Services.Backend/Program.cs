using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShrSolution.AgendamentoWeb.Application.Interfaces;
using ShrSolution.AgendamentoWeb.Application.Mappings;
using ShrSolution.AgendamentoWeb.Application.Services;
using ShrSolution.AgendamentoWeb.Domain.Interfaces;
using ShrSolution.AgendamentoWeb.Domain.Services;
using ShrSolution.AgendamentoWeb.Domain.Services.Interfaces;
using ShrSolution.AgendamentoWeb.Infra.Data.Contexts;
using ShrSolution.AgendamentoWeb.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Application Services
builder.Services.AddScoped<IEmpresaApplicationService, EmpresaApplicationService>();

// Services
builder.Services.AddScoped<IProfessionalService, ProfessionalService>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();

// Repository
builder.Services.AddScoped<IProfissionalRepository, ProfissionalRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();

var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

var config = new MapperConfiguration(
    cfg => {
        cfg.AddMaps(typeof(MappingProfile).Assembly);
    },
    loggerFactory
);

IMapper mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<AgendamentosContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    );
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}