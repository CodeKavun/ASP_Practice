using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Restaurant.Data;
using MVC_Restaurant.Model;
using MVC_Restaurant.Model.DTO;
using MVC_Restaurant.Model.ViewModel;

namespace MVC_Restaurant.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly RestauransContext _context;

        public RestaurantsController(RestauransContext context)
        {
            _context = context;
        }

        // GET: Restaurants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Restaurants.ToListAsync());
        }

        // GET: Restaurants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Restaurants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RestaurantDTO restaurant, IFormFile logo)
        {
            if (ModelState.IsValid)
            {
                Restaurant createdRestaurant = new Restaurant
                {
                    Name = restaurant.Name,
                    Description = restaurant.Description,
                    Adress = restaurant.Adress,
                    Phone = restaurant.Phone,
                    WorkStart = restaurant.WorkStart,
                    WorkEnd = restaurant.WorkEnd
                };

                using MemoryStream ms = new MemoryStream();
                logo.CopyTo(ms);
                byte[] buffer = ms.ToArray();
                createdRestaurant.Logo = buffer;

                _context.Add(createdRestaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            RestaurantDTO restaurantDTO = new RestaurantDTO
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Description = restaurant.Description,
                Adress = restaurant.Adress,
                Phone = restaurant.Phone,
                WorkStart = restaurant.WorkStart,
                WorkEnd = restaurant.WorkEnd
            };

            EditRestaurantViewModel editRestarauntVM = new EditRestaurantViewModel
            {
                Restaurant = restaurantDTO,
                Logo = restaurant.Logo
            };

            return View(editRestarauntVM);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RestaurantDTO restaurantDTO, IFormFile? logo)
        {
            if (id != restaurantDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Restaurant? editedRestaurant = await _context.Restaurants.FindAsync(restaurantDTO.Id);
                if (editedRestaurant == null) return NotFound();

                editedRestaurant.Name = restaurantDTO.Name;
                editedRestaurant.Description = restaurantDTO.Description;
                editedRestaurant.Adress = restaurantDTO.Adress;
                editedRestaurant.Phone = restaurantDTO.Phone;
                editedRestaurant.WorkStart = restaurantDTO.WorkStart;
                editedRestaurant.WorkEnd = restaurantDTO.WorkEnd;

                if (logo != null)
                {
                    using MemoryStream ms = new MemoryStream();
                    logo.CopyTo(ms);
                    byte[] buffer = ms.ToArray();
                    editedRestaurant.Logo = buffer;
                }

                try
                {
                    _context.Update(editedRestaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(restaurantDTO.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            EditRestaurantViewModel editRestarauntVM = new EditRestaurantViewModel
            {
                Restaurant = restaurantDTO
            };
            return View(editRestarauntVM);
        }

        // GET: Restaurants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
            return _context.Restaurants.Any(e => e.Id == id);
        }
    }
}
