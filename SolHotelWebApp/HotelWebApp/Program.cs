using Microsoft.Extensions.Options;
using MongoDB.Driver;
using HotelWebApp.Data;
using HotelWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDBContext.Settings>(
    builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddSingleton<MongoDBContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Rooms}/{action=Index}/{id?}");


app.Run();