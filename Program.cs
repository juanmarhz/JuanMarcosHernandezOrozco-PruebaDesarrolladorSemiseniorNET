using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NumeroAsignadoProject.Application.Interfaces;
using NumeroAsignadoProject.Application.Services;
using NumeroAsignadoProject.Infrastructure.Handlers;
using NumeroAsignadoProject.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<INumeroAsignadoRepository, NumeroAsignadoRepository>();
builder.Services.AddScoped<INumeroAsignadoService, NumeroAsignadoService>();
builder.Services.AddScoped<IApiKeyValidatorRepository, ApiKeyValidatorRepository>();
builder.Services.AddScoped<IApiKeyValidator, ApiKeyValidator>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Configuración de EntityFrameworkContext
builder.Services.AddDbContext<EntityFrameworkContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDB")));

//Configuración de Authentication
builder.Services.AddAuthentication("ApiKeyAuthentication")
        .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>("ApiKeyAuthentication", null);

//Configuración de Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "NumeroAsignadoProject", Version = "v1" });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "ApiKey",
        Description = "Escribe el ApiKey en el campo. Ejemplo de Cabecera: ApiKey 123",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKey",
        BearerFormat = "ApiKey",
    };

    options.AddSecurityDefinition("ApiKey", securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "NumeroAsignadoProject V1");

        // se Habilita la autorización en Swagger UI
        options.OAuthClientId("swagger");
        options.OAuthAppName("NumeroAsignadoProject Swagger UI");
        options.OAuthUsePkce();
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
