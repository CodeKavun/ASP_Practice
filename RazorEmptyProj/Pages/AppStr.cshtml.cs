using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorEmptyProj.Pages
{
    public class AppStrModel : PageModel
    {
        private readonly IConfiguration configuration;

        public string? MyString { get; private set; }

        public AppStrModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void OnGet()
        {
            MyString = configuration.GetValue<string>("MyString");
        }
    }
}
