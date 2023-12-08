using Ecommerce.API.Product.DB;
using Ecommerce.API.Product.Interfaces;
using Ecommerce.API.Product.Providers;
using Microsoft.EntityFrameworkCore;
using AutoMapper; 

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container.

builder.Services.AddScoped<IProductProvider, ProductProvider>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<ProductDbContext>(product =>
{
    product.UseInMemoryDatabase("Products");
});
var app = builder.Build();
//Configure the HTTP request pipeline.

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateTime.Now.AddDays(index),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//}); 
 

app.UseHttpsRedirection();

app.MapControllers();

//app.MapControllers();
app.Run();

//internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}