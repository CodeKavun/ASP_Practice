using MVC_Restaurant.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("MSSQL")
    ?? throw new InvalidOperationException("The connection string is not given");
builder.Services.AddSqlServer<RestauransContext>(connectionString);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllerRoute("default", "{controller=Restaurants}/{action=Index}/{id?}");

app.Run();
