using AutoMapper;
using ECommerce.API.Customers.DB;
using ECommerce.API.Customers.Interfaces;
using ECommerce.API.Customers.Providers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ICustomerProvider, CustomerProvider>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<CustomersDBContext>(customer =>
{
    customer.UseInMemoryDatabase("Customers");
});



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapControllers();

app.Run();

 