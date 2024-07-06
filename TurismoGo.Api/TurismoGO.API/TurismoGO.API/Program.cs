using Microsoft.EntityFrameworkCore;
using TurismoGo.Domain.CORE.Interfaces;
using TurismoGo.Domain.Infrastructure.Data;
using TurismoGo.Domain.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5259); // HTTP
});

// Add services to the container.
var cnx = builder.Configuration.GetConnectionString("DevConnections");
builder.Services.AddDbContext<TurismoDbContext>(options => options.UseSqlServer(cnx));

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IResenaRepository, ResenaRepository>();
builder.Services.AddTransient<IEmpresaTurismoRepository, EmpresaTurismoRepository>();
builder.Services.AddTransient<IReservaRepository, ReservaRepository>();
builder.Services.AddTransient<IRolRepository, RolRepository>();
builder.Services.AddTransient<IActividadRepository, ActividadRepository>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            .AllowAnyOrigin()      // Permite cualquier origen (�CUIDADO! No recomendado en producci�n)
            .AllowAnyMethod()      // Permite cualquier m�todo (GET, POST, PUT, DELETE, etc.)
            .AllowAnyHeader();     // Permite cualquier encabezado
    });

    options.AddPolicy("AllowSpecificOrigins", builder =>
    {
        builder
            .WithOrigins("http://localhost:9000") // Or�genes permitidos
            .WithMethods("GET", "POST") // M�todos permitidos
            .AllowAnyHeader();
    });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting(); // �Importante!

// Habilitar CORS - �Despu�s de UseRouting y antes de UseAuthorization!
app.UseCors(); // Usa la pol�tica por defecto
// O, si tienes pol�ticas espec�ficas:
// app.UseCors("AllowSpecificOrigins"); // Usa la pol�tica "AllowSpecificOrigins"

app.UseAuthorization();

app.MapControllers();

app.Run();