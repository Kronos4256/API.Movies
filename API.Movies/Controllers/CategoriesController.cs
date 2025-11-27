using API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS;
using API.Movies.CAPA_DE_ACCESSO_DATOS.MODELS.Dtos;
using API.Movies.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryservice _categoryService;
        public CategoriesController(ICategoryservice categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet(Name ="CreateCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<CategoryDto>>> GetCategoriesAsync()
        {
            var categoriesDto = await _categoryService.GetCategoriesAsync();
            return Ok(categoriesDto);
        }

        [HttpGet("{id:int}", Name = "GetCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDto>> GetCategoryAsync(int id)
        {
            var categoryDto = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(categoryDto);
        }


        [HttpPost(Name = "CreateCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<CategoryDto>> CreatedCategoryAsync([FromBody] CategoryCreateDto categoryCreateDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdCategory = await _categoryService.CreateCategoryAsync(categoryCreateDto);
                return CreatedAtRoute("GetCategoryAsync", new { id = createdCategory.Id }, createdCategory);
            }
            
            catch(InvalidOperationException ex) when (ex.Message.Contains("Ya existe una categoría"))
            {
                return Conflict(new { ex.Message});
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
       


        }
    }
}
