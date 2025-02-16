namespace Animals_Figures.Services.Abstract
{
    public interface IAnimalSender
    {
        Task GetAnimal(HttpContext context);
    }
}
