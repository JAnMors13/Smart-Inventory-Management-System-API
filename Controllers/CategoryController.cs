using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smart_Inventory_Management_System.DTOs.Category;
using Smart_Inventory_Management_System.Interface;
using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var category = await _categoryRepo.GetAllCategoriesAsync();
            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(category);

            return Ok(categoryDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var category = await _categoryRepo.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var categoryModel = _mapper.Map<Category>(createDto);
            await _categoryRepo.CreateCategoryAsync(categoryModel);

            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryModel.Id }, _mapper.Map<CategoryDto>(categoryModel));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] UpdateCategoryRequestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var categoryModel = await _categoryRepo.UpdateCategoryAsync(id, updateDto);
            if (categoryModel == null) return NotFound();

            return Ok(_mapper.Map<CategoryDto>(categoryModel));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var category = await _categoryRepo.DeleteCategoryByIdAsync(id);
            if (category == null) return NotFound();

            return NoContent();
        }
    }
}
