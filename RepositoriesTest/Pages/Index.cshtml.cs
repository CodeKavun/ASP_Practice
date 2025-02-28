using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoriesTest.Models;
using RepositoriesTest.Services.Abstract;

namespace RepositoriesTest.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Film> Films { get; set; }
        private readonly IRepository<Film> repository;

        public IndexModel(IRepository<Film> repository)
        {
            this.repository = repository;
        }

        public void OnGet()
        {
            Films = repository.GetAll();
        }
    }
}
