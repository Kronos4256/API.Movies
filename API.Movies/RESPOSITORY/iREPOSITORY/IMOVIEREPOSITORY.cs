using API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS;

namespace API.Movies.RESPOSITORY.iREPOSITORY
{
    public interface IMOVIEREPOSITORY
    {
        Task<ICollection<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<bool> MovieExistsByIdAsync(int id);
        Task<bool> MovieExistsByNameAsync(string name);
        Task<bool> CreateMovieAsync(Movie movie);
        Task<bool> UpdateMovieAsync(Movie movie);
        Task<bool> DeleteMovieAsync(int id);
    }
}