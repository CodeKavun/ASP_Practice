using Animals_Figures.Services.Abstract;

namespace Animals_Figures.Services.Implementation
{
    public class Carrot : IAnimal
    {
        public string Name { get; init; }

        public Carrot(string name)
        {
            Name = name;
        }

        public string PlaySound()
        {
            throw new NotImplementedException();
        }
    }
}
