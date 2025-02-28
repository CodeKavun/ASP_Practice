using RepositoriesTest.Models;
using RepositoriesTest.Services.Abstract;

namespace RepositoriesTest.Services.Implementation
{
    public class BasicFilmRepository : IRepository<Film>
    {
        private ICollection<Film> films = [];

        public Film Create(Film entity)
        {
            int id = 0;
            if (films.Count > 0) id = films.Max(f => f.Id);

            entity.Id = id + 1;
            films.Add(entity);
            return entity;
        }

        public Film? Delete(int id)
        {
            Film? deletedFilm = films.FirstOrDefault(f => f.Id == id);
            if (deletedFilm != null) films.Remove(deletedFilm);
            return deletedFilm;
        }

        public Film Edit(Film entity)
        {
            Film? editedFilm = films.FirstOrDefault(f => f.Id == entity.Id);
            if (editedFilm == null) return entity;

            editedFilm.Title = entity.Title;
            editedFilm.ReleaseYear = entity.ReleaseYear;

            return editedFilm;
        }

        public Film? Get(int id)
        {
            Film? film = films.FirstOrDefault(f => f.Id == id);
            return film;
        }

        public IEnumerable<Film> GetAll()
        {
            return [.. films];
        }
    }
}
