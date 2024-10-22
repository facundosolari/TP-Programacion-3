using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation();

// tipo de vida, singleton: existe una única vez para toda la app
// scoped: se usa una vez por instancia
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();

builder.Services.AddScoped<IAppartmentService, AppartmentService>();
builder.Services.AddScoped<IAppartmentRepository, AppartmentRepository>();

builder.Services.AddDbContext<ProjectContext>(dbContextOptions => dbContextOptions.UseSqlite(
    builder.Configuration["ConnectionStrings:ProjectDBConnectionString"], b => b.MigrationsAssembly("Infrastructure")));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
