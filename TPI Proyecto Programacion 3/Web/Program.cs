using Domain.Interfaces;
using Application.Services;
using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Models.AuthenticationModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<ProjectContext>(dbContextOptions => dbContextOptions.UseSqlite(
    builder.Configuration["ConnectionStrings:ProjectDBConnectionString"], b => b.MigrationsAssembly("Infrastructure")));

builder.Services.Configure<AuthenticationServiceOptions>(builder.Configuration.GetSection("AuthenticationServiceOptions"));

builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("InmobiliariaApiBearerAuth", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Pega el token o toka de aca."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "InmobiliariaApiBearerAuth"
                        }
                    },
                    new List<string>()
                }
            });
});

builder.Services.AddAuthentication("Bearer")
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["AuthenticationServiceOptions:Issuer"],
                    ValidAudience = builder.Configuration["AuthenticationServiceOptions:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["AuthenticationServiceOptions:SecretForKey"]!))
                };

                options.Events = new JwtBearerEvents
                {
                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        context.Response.ContentType = "text/plain";
                        return context.Response.WriteAsync("Error. No tienes acceso a esta opción.");
                    },
                    OnAuthenticationFailed = context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized; 
                        context.Response.ContentType = "text/plain";
                        return context.Response.WriteAsync("Token no válido.");
                    }
                };
            }
        );

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
// tipo de vida, singleton: existe una única vez para toda la app
// scoped: se usa una vez por instancia
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();

builder.Services.AddScoped<IBuildingService, BuildingService>();
builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();

builder.Services.AddScoped<IAppartmentService, AppartmentService>();
builder.Services.AddScoped<IAppartmentRepository, AppartmentRepository>();

builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<ITenantRepository, TenantRepository>();

builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
