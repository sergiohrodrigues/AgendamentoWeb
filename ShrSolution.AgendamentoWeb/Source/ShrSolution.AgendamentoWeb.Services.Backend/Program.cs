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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

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

builder.Services.AddDbContext<AgendamentoWebContext>(options =>
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

app.Run();