using API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS;
using API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS.Dtos;
using AutoMapper;

namespace API.Movies.MOVIESMAPPER
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
        }
    }
}
