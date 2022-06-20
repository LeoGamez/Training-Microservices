using AutoMapper;
using Discount.Application;
using Discount.Application.Models;
using Discount.Infrastructure.Extensions;
using Discount.Infrastructure.Repositories;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//! Add automapper
var config = new MapperConfiguration(cfg => cfg.AddProfile(new CouponProfile()));
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

//! Add Repositories
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();

//! Add MediatR
var assembly = ApplicationAssembly.GetAssembly();
builder.Services.AddMediatR(assembly);

var app = builder.Build();

app.MigrateDatabase<Program>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
