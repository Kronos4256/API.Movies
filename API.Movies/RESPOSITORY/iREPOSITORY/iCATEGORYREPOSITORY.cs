using API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS;

namespace API.Movies.RESPOSITORY.iREPOSITORY
{
    public interface iCATEGORYREPOSITORY
    {
        Task<ICollection<Category>> GetCategoriesAsync();//Me retorna una lista de categorias
        Task<Category> GetCategoryByIdAsync(int categoryId);//Me retorna una categoria por su id
        Task<bool> CategoryExistsByIdAsync(int categoryId);//Me indica si una categoria existe por su id
        Task<bool> CategoryExistsByNameAsync(string categoryName);//Me indica si una categoria existe por su nombre
        Task<bool> CreateCategoryAsync(Category category);//Me crea una nueva categoria
        Task<bool> UpdateCategoryAsync(Category category);//Me actualiza una categoria
        Task<bool> DeleteCategoryAsync(int categoryId);//Me elimina una categoria
    }
}
