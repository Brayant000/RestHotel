using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestHotel.Infrastructure.Persistence.Context;
using RestHotel.Infrastructure.Persistence.Interfaces;
using RestHotel.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicio de base de datos en memoria
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer("HotelDB"));

// Registrar repositorios
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();