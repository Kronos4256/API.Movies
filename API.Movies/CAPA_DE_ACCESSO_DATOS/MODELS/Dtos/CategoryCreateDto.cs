using System.ComponentModel.DataAnnotations;

namespace API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS.Dtos
{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "El nombre de la categoria es obligatorio. ")]
        [MaxLength(100, ErrorMessage = "El número máximo de caracteres es 100. ")]
        public string Name { get; set; }
    }
}
