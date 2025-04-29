using Microsoft.EntityFrameworkCore;
using WebApi8_Scheduling.Data;
using WebApi8_Scheduling.Services.Client;
using WebApi8_Scheduling.Services.Scheduling;
using WebApi8_Scheduling.Services.Time;
using WebApi8_Scheduling.Services.User;

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

//builder.Services.AddScoped<IEnterpriseInterface, EnterpriseService>();
//builder.Services.AddScoped<IClientInterface, ClientService>();
builder.Services.AddScoped<ISchedulingInterface, SchedulingService>();
builder.Services.AddScoped<IServiceInterface, ServiceService>();
builder.Services.AddScoped<ITimeService, TimeService>();

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
