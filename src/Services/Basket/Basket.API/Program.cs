using AutoMapper;
using Basket.Application;
using Basket.Application.Models;
using Basket.Infrastructure.Repositories;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//! Add automapper
var config = new MapperConfiguration(cfg => cfg.AddProfile(new BasketProfile()));
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

//! Add Redis
builder.Services.AddStackExchangeRedisCache(options => options.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString"));

//! Add Repositories
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

//! Add MediatR
var assembly = ApplicationAssembly.GetAssembly();
builder.Services.AddMediatR(assembly);

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
