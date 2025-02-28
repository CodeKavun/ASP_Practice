using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoriesTest.Models;
using RepositoriesTest.Services.Abstract;

namespace RepositoriesTest.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty] public Film Film { get; set; } = new Film();

        private readonly IRepository<Film> repository;

        public EditModel(IRepository<Film> repository)
        {
            this.repository = repository;
        }

        public void OnGet(int id)
        {
            Film = repository.Get(id) ?? new Film();
        }

        public IActionResult OnPost()
        {
            repository.Edit(Film);
            return RedirectToPage("Index");
        }
    }
}
