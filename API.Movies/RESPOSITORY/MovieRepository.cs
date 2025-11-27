using API.Movies.CAPA_DE_ACCESSO_DATOS;
using API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS;
using API.Movies.RESPOSITORY.iREPOSITORY;
using Microsoft.EntityFrameworkCore;

namespace API.Movies.RESPOSITORY
{
    public class MovieRepository : IMOVIEREPOSITORY
    {
        private readonly ApplicationDbcontext _context;

        public MovieRepository(ApplicationDbcontext context)
        {
            _context = context;
        }

        public async Task<bool> CreateMovieAsync(Movie movie)
        {
            movie.CreatedDate = DateTime.UtcNow; 
            await _context.Movies.AddAsync(movie);
            return await SaveAsync();
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var movie = await GetMovieByIdAsync(id);
            if (movie == null) return false;

            _context.Movies.Remove(movie);
            return await SaveAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<ICollection<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.AsNoTracking().OrderBy(m => m.Name).ToListAsync();
        }

        public async Task<bool> MovieExistsByIdAsync(int id)
        {
            return await _context.Movies.AsNoTracking().AnyAsync(m => m.Id == id);
        }

        public async Task<bool> MovieExistsByNameAsync(string name)
        {
            return await _context.Movies.AsNoTracking().AnyAsync(m => m.Name == name);
        }

        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            movie.ModifiedDate = DateTime.UtcNow; 
            _context.Movies.Update(movie);
            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}