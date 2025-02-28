using Microsoft.EntityFrameworkCore;
using RepositoriesTest.Data;
using RepositoriesTest.Models;
using RepositoriesTest.Services.Abstract;
using RepositoriesTest.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

string connectionString = builder.Configuration.GetConnectionString("MSSQL") ?? throw new InvalidOperationException("There should be connection string!");
builder.Services.AddDbContext<CinemaContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IRepository<Film>, DatabaseFilmRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.UseDefaultFiles();
app.MapRazorPages();

app.Run();
