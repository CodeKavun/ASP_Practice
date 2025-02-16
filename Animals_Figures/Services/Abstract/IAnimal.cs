namespace Animals_Figures.Services.Abstract
{
    public interface IAnimal
    {
        string Name { get; init; }
        string PlaySound();
    }
}
