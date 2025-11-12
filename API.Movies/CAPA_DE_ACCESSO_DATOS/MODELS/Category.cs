using System.ComponentModel.DataAnnotations;

namespace API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS
{
    public class Category : AuditBase
    {
        [Required]//Indica que el campo es obligatorio
        [Display(Name="Nombre de la categoria")]//Me sirve para mostrar un nombre amigable en las vistas o mensaje de error
        public String Name { get; set; }
    }
}

