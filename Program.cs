using Microsoft.EntityFrameworkCore;
using Programacion2ClientesAPI.Data;
using Programacion2ClientesAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException(
        "No se encontró la cadena de conexión 'DefaultConnection'.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    )
);

builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:5122")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("BlazorPolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();
