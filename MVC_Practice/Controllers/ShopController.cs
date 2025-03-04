using Microsoft.AspNetCore.Mvc;

namespace MVC_Practice.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
