using Microsoft.AspNetCore.Identity;
using MottuApi;
using MottuApi.Business;
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
//builder.Services.AddScoped<>();
//builder.Services.AddScoped<>();
//builder.Services.AddScoped<>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use((context, next) =>
{
    // Non authenticated routes
    if (!context.Request.Path.StartsWithSegments("/api/auth"))
        context.Response.WriteAsync("Hello from inline middleware!");

    return next(context);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
