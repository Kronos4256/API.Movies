using API.Movies.CAPA_DE_ACCESSO_DATOS;
using API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS;
using API.Movies.RESPOSITORY.iREPOSITORY;
using Microsoft.EntityFrameworkCore;

namespace API.Movies.RESPOSITORY
{
    public class CategoryRepository : iCATEGORYREPOSITORY
    {
       private  readonly ApplicationDbcontext _context;
        public CategoryRepository(ApplicationDbcontext context)
        {
            _context = context;
        }

        public async Task<bool> CategoryExistsByIdAsync(int categoryId)
        {
            return await _context.Categories
                .AsNoTracking()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<bool> CategoryExistsByNameAsync(string categoryName)
        {
            return await _context.Categories
                .AsNoTracking()
                .AnyAsync(c => c.Name == categoryName);
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            category.CreatedDate= DateTime.UtcNow;

            await _context.Categories.AddAsync(category);

            return await SaveAsync();
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var categoryToDelete = await GetCategoryByIdAsync(categoryId);
            if (categoryToDelete == null)
            { 
                return false;
            }
            _context.Categories.Remove(categoryToDelete);
            return await SaveAsync();

        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return await _context.Categories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToListAsync();
               
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c =>c.Id== categoryId);
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            category.ModifiedDate = DateTime.UtcNow;

            _context.Categories.Update(category);

            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
