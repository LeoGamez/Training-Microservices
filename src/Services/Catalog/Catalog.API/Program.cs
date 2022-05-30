using AutoMapper;
using Catalog.Application;
using Catalog.Application.Queries.GetProducts;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add automapper

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new GetProductsProfile());
});

var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

// Add MediatR

builder.Services.AddMediatR(typeof(ApplicationAssembly).Assembly);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

