using RepositoriesTest.Data;
using RepositoriesTest.Models;
using RepositoriesTest.Services.Abstract;

namespace RepositoriesTest.Services.Implementation
{
    public class DatabaseFilmRepository : IRepository<Film>
    {
        private readonly CinemaContext context;

        public DatabaseFilmRepository(CinemaContext context)
        {
            this.context = context;
        }

        public Film Create(Film entity)
        {
            context.Films.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public Film? Delete(int id)
        {
            Film? deletedFilm = context.Films.Find(id);

            if (deletedFilm is not null)
            {
                context.Films.Remove(deletedFilm);
                context.SaveChanges();
            }

            return deletedFilm;
        }

        public Film Edit(Film entity)
        {
            Film? editedFilm = context.Films.Find(entity.Id);

            if (editedFilm is not null)
            {
                editedFilm.Title = entity.Title;
                editedFilm.ReleaseYear = entity.ReleaseYear;
                context.SaveChanges();
                return editedFilm;
            }

            return entity;
        }

        public Film? Get(int id)
        {
            Film? film = context.Films.Find(id);
            return film;
        }

        public IEnumerable<Film> GetAll()
        {
            return [.. context.Films];
        }
    }
}
