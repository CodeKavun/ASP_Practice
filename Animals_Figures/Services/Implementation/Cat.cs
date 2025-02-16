using Animals_Figures.Services.Abstract;

namespace Animals_Figures.Services.Implementation
{
    public class Cat : IAnimal
    {
        public string Name { get; init; }

        public Cat(string name)
        {
            Name = name;
        }

        public string PlaySound()
        {
            throw new NotImplementedException();
        }
    }
}
