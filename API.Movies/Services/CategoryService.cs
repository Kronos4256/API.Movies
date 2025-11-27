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
        public CategoryService(iCATEGORYREPOSITORY categoryRepository, IMapper mapper)
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

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateUpdateDto categoryCreateDto)
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

            return _mapper.Map<ICollection<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(categoryId);

            return _mapper.Map<CategoryDto>(category);
        }


        public async Task<CategoryDto> UpdateCategoryAsync(CategoryCreateUpdateDto dto, int id)
        {
            var categoryExists = await _categoryRepository.GetCategoryByIdAsync(id);
            if (categoryExists == null)
            {
                throw new InvalidOperationException($"No se encontró la categoria con ID:'{id}'");
            }
            var nameExists = await _categoryRepository.CategoryExistsByNameAsync(dto.Name);
            if (nameExists)
            {
                throw new InvalidOperationException($"Ya existe una categoría con el nombre de '{dto.Name}'");
            }

            _mapper.Map(dto, categoryExists);
            var categoryUpdated = await _categoryRepository.UpdateCategoryAsync(categoryExists);
            if (!categoryUpdated)
            {
                throw new Exception("Error al actualizar la categoría.");
            }
            return _mapper.Map<CategoryDto>(categoryExists);
        }
    }
}
