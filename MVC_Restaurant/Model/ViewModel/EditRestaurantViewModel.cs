﻿using MVC_Restaurant.Model.DTO;

namespace MVC_Restaurant.Model.ViewModel
{
    public class EditRestaurantViewModel
    {
        public RestaurantDTO RestaurantDTO { get; set; } = default!;
        public byte[] Logo { get; set; } = default!;
    }
}
