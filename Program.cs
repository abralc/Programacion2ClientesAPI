using Microsoft.EntityFrameworkCore;
using Programacion2ClientesAPI.Data;
using Programacion2ClientesAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

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

// Ocultar encabezado Server: Kestrel
builder.WebHost.ConfigureKestrel(options =>
{
    options.AddServerHeader = false;
});

var app = builder.Build();

// Cabeceras de seguridad para TODAS las respuestas,
// incluyendo Swagger y endpoints de la API.
app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        context.Response.Headers["X-Content-Type-Options"] = "nosniff";

        context.Response.Headers["X-Frame-Options"] = "DENY";

        context.Response.Headers["Referrer-Policy"] =
            "strict-origin-when-cross-origin";

        context.Response.Headers["Permissions-Policy"] =
            "camera=(), microphone=(), geolocation=()";

        return Task.CompletedTask;
    });

    await next();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("BlazorPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();