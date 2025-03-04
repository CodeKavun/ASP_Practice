using Microsoft.AspNetCore.Mvc;

namespace MVC_Practice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task OurTeam()
        {
            await Response.WriteAsync("<h1>Our Stuff</h1>");
        }
    }
}
