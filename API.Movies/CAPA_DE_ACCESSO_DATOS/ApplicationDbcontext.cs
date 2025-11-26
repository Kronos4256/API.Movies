using API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS;
using Microsoft.EntityFrameworkCore;

namespace API.Movies.CAPA_DE_ACCESSO_DATOS
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext>options):base(options)
        {
            
        }

        //Sección para crear el dbset de las entidades o modelos    
        public DbSet<Category> Categories { get; set; }
    }
}
