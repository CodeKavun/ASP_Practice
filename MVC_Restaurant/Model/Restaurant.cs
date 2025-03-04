namespace MVC_Restaurant.Model
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Adress { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public TimeOnly WorkStart { get; set; }
        public TimeOnly WorkEnd { get; set; }
        public byte[] Logo { get; set; } = default!;
    }
}
