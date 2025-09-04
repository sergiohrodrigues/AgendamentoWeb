using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.UseUrls("http://0.0.0.0:80");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddScoped<IEmpresaInterface, EmpresaService>();
// builder.Services.AddScoped<IClienteInterface, ClienteService>();
// builder.Services.AddScoped<IAgendamentoInterface, AgendamentoService>();
// builder.Services.AddScoped<IServicoInterface, ServicoServico>();
// builder.Services.AddScoped<ITimeService, TimeService>();
// builder.Services.AddScoped<IProfessionalService, ProfessionalService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        //builder.Configuration.GetConnectionString("DefaultConnection"),
        builder.Configuration.GetConnectionString("TestConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    );
});

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
