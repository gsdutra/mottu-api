using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using MottuApi;
using MottuApi.Business;
using MottuApi.Middlewares;
using MottuApi.Model;
using MottuApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services.AddDbContext<DataContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<MotorcycleBusiness>();
builder.Services.AddScoped<MotorcycleRepository>();
builder.Services.AddScoped<AuthBusiness>();
builder.Services.AddScoped<AuthRepository>();
builder.Services.AddScoped<DeliveryPersonBusiness>();
builder.Services.AddScoped<DeliveryPersonRepository>();
builder.Services.AddScoped<RentalBusiness>();
builder.Services.AddScoped<RentalRepository>();

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
