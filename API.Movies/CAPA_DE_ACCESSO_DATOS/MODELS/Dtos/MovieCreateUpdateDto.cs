using System.ComponentModel.DataAnnotations;

namespace API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS.Dtos
{
    public class MovieCreateUpdateDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El número máximo de caracteres es 100.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La duración es obligatoria.")]
        public int Duration { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "La clasificación es obligatoria.")]
        [MaxLength(10, ErrorMessage = "La clasificación no puede exceder 10 caracteres.")]
        public string Clasification { get; set; }
    }
}