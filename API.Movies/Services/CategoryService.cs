using API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS;
using API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS.Dtos;
using API.Movies.MOVIESMAPPER;
using API.Movies.RESPOSITORY;
using API.Movies.RESPOSITORY.iREPOSITORY;
using API.Movies.Services.IServices;
using AutoMapper;

namespace API.Movies.Services
{
    public class CategoryService : ICategoryservice
    {
        private readonly iCATEGORYREPOSITORY _categoryRepository;
        private readonly IMapper _mapper;  
        public CategoryService(iCATEGORYREPOSITORY categoryRepository, IMapper mapper   )
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public Task<bool> CategoryExistsByIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CategoryExistsByNameAsync(string categoryName)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
        {
           var categoryExists = await _categoryRepository.CategoryExistsByNameAsync(categoryCreateDto.Name);
            if (categoryExists)
            {
                throw new InvalidOperationException($"Ya existe una categoría con el nombre de '{categoryCreateDto.Name}'");
            }
            var category = _mapper.Map<Category>(categoryCreateDto);
            var createdCategory = await _categoryRepository.CreateCategoryAsync(category);

            if (!createdCategory)
            {
                throw new Exception("Error al crear la categoría.");
            }
            return _mapper.Map<CategoryDto>(category);
        }

        //public Task<bool> CreateCategoryAsync(Category category)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();

            return  _mapper.Map<ICollection<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);

            return _mapper.Map<CategoryDto>(category);
        }

        public Task<bool> UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
