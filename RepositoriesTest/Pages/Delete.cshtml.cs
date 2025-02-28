using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoriesTest.Models;
using RepositoriesTest.Services.Abstract;

namespace RepositoriesTest.Pages
{
    public class DeleteModel : PageModel
    {
        public Film Film { get; set; } = new Film();
        private readonly IRepository<Film> repository;

        public DeleteModel(IRepository<Film> repository)
        {
            this.repository = repository;
        }

        public void OnGet(int id)
        {
            Film = repository.Get(id) ?? new Film();
        }

        public IActionResult OnPost(int id)
        {
            repository.Delete(id);
            return RedirectToPage("Index");
        }
    }
}
