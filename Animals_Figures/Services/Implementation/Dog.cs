using Animals_Figures.Services.Abstract;

namespace Animals_Figures.Services.Implementation
{
    public class Dog : IAnimal
    {
        public string Name { get; init; }

        public Dog(string name)
        {
            Name = name;
        }

        public string PlaySound()
        {
            throw new NotImplementedException();
        }
    }
}
