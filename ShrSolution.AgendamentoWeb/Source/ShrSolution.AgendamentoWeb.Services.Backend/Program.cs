using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShrSolution.AgendamentoWeb.Application.Interfaces;
using ShrSolution.AgendamentoWeb.Application.Mappings;
using ShrSolution.AgendamentoWeb.Application.Services;
using ShrSolution.AgendamentoWeb.Domain.Interfaces;
using ShrSolution.AgendamentoWeb.Domain.Repositories;
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
builder.Services.AddScoped<IProfissionalApplicationService, ProfissionalApplicationService>();
builder.Services.AddScoped<IClienteApplicationService, ClienteApplicationService>();
builder.Services.AddScoped<IServicoApplicationService, ServicoApplicationService>();
builder.Services.AddScoped<IAgendamentoApplicationService, AgendamentoApplicationService>();

// Services
builder.Services.AddScoped<IProfissionalService, ProfissionalService>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IServicoService, ServicoService>();
builder.Services.AddScoped<IAgendamentoService, AgendamentoService>();

// Repository
builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
builder.Services.AddScoped<IProfissionalRepository, ProfissionalRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IServicoRepository, ServicoRepository>();
builder.Services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();

var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

var config = new MapperConfiguration(
    cfg => {
        cfg.AddMaps(typeof(ViewModelParaDomain).Assembly);
        cfg.AddMaps(typeof(DomainParaViewModel).Assembly);
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