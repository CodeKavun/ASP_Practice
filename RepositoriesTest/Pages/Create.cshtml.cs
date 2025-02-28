using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoriesTest.Models;
using RepositoriesTest.Services.Abstract;

namespace RepositoriesTest.Pages
{
    public class CreateModel : PageModel
    {
        [BindProperty] public Film Film { get; set; } = new Film();

        private readonly IRepository<Film> repository;

        public CreateModel(IRepository<Film> repository)
        {
            this.repository = repository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid && Film is not null)
            {
                repository.Create(Film);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
