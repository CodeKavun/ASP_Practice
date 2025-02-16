using Animals_Figures.Services.Abstract;
using Animals_Figures.Services.Implementation;
using System.Text;

namespace Animals_Figures.Middleware
{
    public class AnimalMiddleware
    {
        private readonly RequestDelegate next;

        public AnimalMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAnimal animal)
        {
            string path = context.Request.Path;

            if (!string.IsNullOrEmpty(path) && ContainsAnimalName(path.ToLower()))
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append("<h1>You have animal with properties:</h1>");
                stringBuilder.Append($"<b>Name:<b> {animal.Name}");
                stringBuilder.Append($"<b>Sound:<b> {animal.PlaySound()}");


            }
        }

        private bool ContainsAnimalName(string path) => path == "/animal/cat" || path == "/animal/dog" || path == "/animal/carrot";
    }
}
