using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", ctx =>
{
    ctx.Response.Redirect("/home");
    return Task.CompletedTask;
});
app.MapGet("/home", () => "Dmytro Chapny");
app.MapGet("/home/name", () => $"{app.Environment.ApplicationName}, {DateTime.Now.ToLongTimeString()}");
app.MapGet("/home/buisness", GetPage);
app.MapGet("/home/fibonacci", GetFibonacci);

async Task GetPage(HttpContext context)
{
    StringBuilder sb = new StringBuilder();
    sb.Append("<h1>My buisness today</h1>");
    sb.Append("<ul>");
    sb.Append("<li>Go to the park</li>");
    sb.Append("<li>Play <strong>Stalker 2</strong></li>");
    sb.Append("<li>Proceed making my game on <strong>C# Monogame</strong></li>");
    sb.Append("<li>Sleep</li>");
    sb.Append("<li>Sleep</li>");
    sb.Append("<li>Sleep</li>");
    sb.Append("<li>and Sleep</li>");
    sb.Append("</ul>");

    context.Response.Headers.Append("Content-Type", "text/html;charset=utf-8");
    await context.Response.WriteAsync(sb.ToString());
}

async Task GetFibonacci(HttpContext context)
{
    string? requestedLength = context.Request.Query["index"];

    if (requestedLength != null
        && int.TryParse(requestedLength, out int length)
        && length >= 0 && length <= 40)
    {
        int result = FibonacciNumber(length);

        await context.Response.WriteAsync(result.ToString());
    }
    else await context.Response.WriteAsync("We have trouble with your mystical number!");
}

int FibonacciNumber(int n)
{
    if (n <= 1) return n;
    return FibonacciNumber(n - 1) + FibonacciNumber(n - 2);
}

app.Run();
