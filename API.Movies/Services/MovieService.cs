using API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS;
using API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS.Dtos;
using API.Movies.RESPOSITORY.iREPOSITORY;
using API.Movies.Services.IServices;
using AutoMapper;

namespace API.Movies.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMOVIEREPOSITORY _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMOVIEREPOSITORY movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieDto)
        {
            // Validar nombre único
            var exists = await _movieRepository.MovieExistsByNameAsync(movieDto.Name);
            if (exists)
            {
                throw new InvalidOperationException($"Ya existe una película con el nombre '{movieDto.Name}'");
            }

            var movie = _mapper.Map<Movie>(movieDto);
            var result = await _movieRepository.CreateMovieAsync(movie);

            if (!result) throw new Exception("Error al crear la película.");

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            var exists = await _movieRepository.MovieExistsByIdAsync(id);
            if (!exists)
            {
                throw new InvalidOperationException($"No se encontró la película con ID: {id}");
            }

            var result = await _movieRepository.DeleteMovieAsync(id);
            if (!result) throw new Exception("Error al eliminar la película.");

            return result;
        }

        public async Task<MovieDto> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(id);
            if (movie == null)
            {
                throw new InvalidOperationException($"No se encontró la película con ID: {id}");
            }
            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public async Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto dto, int id)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(id);
            if (movie == null)
            {
                throw new InvalidOperationException($"No se encontró la película con ID: {id}");
            }

           
            _mapper.Map(dto, movie);

            var result = await _movieRepository.UpdateMovieAsync(movie);
            if (!result) throw new Exception("Error al actualizar la película.");

            return _mapper.Map<MovieDto>(movie);
        }
    }
}