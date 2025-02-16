using Animals_Figures.Services.Abstract;
using System.Text;

namespace Animals_Figures.Services.Implementation
{
    public class HtmlAnimalSender : IAnimalSender
    {
        private readonly IAnimal animal;

        public HtmlAnimalSender(IAnimal animal)
        {
            this.animal = animal;
        }

        public async Task GetAnimal(HttpContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("<h1>You have animal with properties:</h1>");
            stringBuilder.Append($"<b>Name:<b> {animal.Name}");
            stringBuilder.Append($"<b>Sound:<b> {animal.PlaySound()}");

            context.Response.ContentType = "text/html;charset=utf-8";
            await context.Response.WriteAsync(stringBuilder.ToString());
        }
    }
}
