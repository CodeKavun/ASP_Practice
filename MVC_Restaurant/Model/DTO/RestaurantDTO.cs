using System.ComponentModel.DataAnnotations;

namespace MVC_Restaurant.Model.DTO
{
    public class RestaurantDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Adress { get; set; } = default!;
        [Display(Name = "Phine Number")]
        public string Phone { get; set; } = default!;
        [Display(Name = "Start of Work")]
        public TimeOnly WorkStart { get; set; }
        [Display(Name = "End of Work")]
        public TimeOnly WorkEnd { get; set; }
    }
}
