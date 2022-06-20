using AutoMapper;
using Discount.Grpc.Mapper;
using Discount.Grpc.Services;
using Discount.Infrastructure.Extensions;
using Discount.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

//! Add services to the container.
builder.Services.AddGrpc();

//! Add automapper
var config = new MapperConfiguration(cfg => cfg.AddProfile(new DiscountProfile()));
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

//! Add Repositories
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();

var app = builder.Build();

app.MigrateDatabase<Program>();

app.MapGrpcService<DiscountService>();

// Configure the HTTP request pipeline.
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
