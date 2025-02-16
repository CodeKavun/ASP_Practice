using FibonacciDependecy_HW.Services.Abstract;
using System.Text;

namespace FibonacciDependecy_HW.Middleware
{
    public class FibonacciMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IFibonacci fibonacci;

        public FibonacciMiddleware(RequestDelegate next, IFibonacci fibonacci)
        {
            this.next = next;
            this.fibonacci = fibonacci;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path;
            string? index = context.Request.Query["index"];

            if (!string.IsNullOrEmpty(path) && path == "/fibonacci" && !string.IsNullOrWhiteSpace(index)
                && int.TryParse(index, out int indexValue))
            {
                int result = fibonacci.CalculateFibonacci(indexValue);

                StringBuilder sb = new StringBuilder();

                sb.Append("<h3>");
                sb.Append("The result of <i>fibonacci calculation</i> is ");
                sb.Append(result);

                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(sb.ToString());
            }
            else await next(context);
        }
    }
}
