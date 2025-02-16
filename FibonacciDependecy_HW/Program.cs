using FibonacciDependecy_HW.Middleware;
using FibonacciDependecy_HW.Services.Abstract;
using FibonacciDependecy_HW.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IFibonacci, FibonacciService>();
var app = builder.Build();

app.UseMiddleware<FibonacciMiddleware>();

//app.Use(async (context) =>
//{

//});
app.MapGet("/", async context =>
{
    string someText = "<h1>Hi</h1>";
    await context.Response.WriteAsync(someText);
});

app.Run();
