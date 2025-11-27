using API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS;
using API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS.Dtos;

namespace API.Movies.Services.IServices
{
    public interface ICategoryservice
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync();//Me retorna una lista de categorias
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateUpdateDto categoryDto);//Me crea una nueva categoria y me retorna el dto
        Task<CategoryDto> GetCategoryByIdAsync(int categoryId);//Me retorna una categoria por su id
        Task<bool> CategoryExistsByIdAsync(int categoryId);//Me indica si una categoria existe por su id
        Task<bool> CategoryExistsByNameAsync(string categoryName);//Me indica si una categoria existe por su nombre
        //Task<bool> CreateCategoryAsync(Category category);//Me crea una nueva categoria
        Task<CategoryDto> UpdateCategoryAsync(CategoryCreateUpdateDto dto, int id);//Me actualiza una categoria
        Task <bool> DeleteCategoryAsync(int categoryId) ;//Me elimina una categoria
    }

}
