using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smart_Inventory_Management_System.DTOs.OrderItem;
using Smart_Inventory_Management_System.DTOs.Product;
using Smart_Inventory_Management_System.Interface;
using Smart_Inventory_Management_System.Models;

namespace Smart_Inventory_Management_System.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepo;
        public ProductController(IProductRepository productRepo, IMapper mapper, ICategoryRepository categoryRepo)
        {
            _productRepo = productRepo;
            _mapper = mapper;
            _categoryRepo = categoryRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var product = await _productRepo.GetAllProductsAsync();
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(product);

            return Ok(productDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var product = await _productRepo.GetProductByIdAsync(id);
            if (product == null) return NotFound();

            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPost("{categoryId:int}")]
        public async Task<IActionResult> CreateProduct([FromRoute] int categoryId, [FromBody] CreateProductRequestDto createDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _categoryRepo.CategoryExistsAsync(categoryId))
                return BadRequest("Category does not exists");

            var productModel = _mapper.Map<Product>(createDto);
            productModel.CategoryId = categoryId;
            await _productRepo.CreateProductAsync(productModel);

            return CreatedAtAction(nameof(GetProductById), new { id = productModel.Id }, _mapper.Map<ProductDto>(productModel));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody]  UpdateProductRequestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _categoryRepo.CategoryExistsAsync(updateDto.CategoryId))
            {
                return BadRequest("Invalid CategoryId. The specified category does not exist.");
            }

            var product = await _productRepo.UpdateProductAsync(id, _mapper.Map<UpdateProductRequestDto>(updateDto));
            if(product == null) return NotFound("Product not Found");

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var product = await _productRepo.DeleteProductAsync(id);
            if (product == null) return NotFound("Product does not exists");
            
            return Ok(product);
        }
    }
}
