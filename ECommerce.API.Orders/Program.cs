using AutoMapper;
using ECommerce.API.Orders.DB;
using ECommerce.API.Orders.Interfaces;
using ECommerce.API.Orders.Providers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IOrderProvider, OrderProvider>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<OrderDBContext>(option =>
{
    option.UseInMemoryDatabase("Orders");
});

var app = builder.Build();
app.MapControllers();
app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.Run();
