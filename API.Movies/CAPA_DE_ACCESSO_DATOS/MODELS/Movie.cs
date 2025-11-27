using System.ComponentModel.DataAnnotations;

namespace API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS
{
    public class Movie : AuditBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La duración es obligatoria")]
        public int Duration { get; set; }

       
        public string? Description { get; set; }

        [Required(ErrorMessage = "La clasificación es obligatoria")]
        [MaxLength(10, ErrorMessage = "La clasificación no puede exceder los 10 caracteres")]
        public string Clasification { get; set; }
    }
}