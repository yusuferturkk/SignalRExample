using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRExample.Business.Abstract;
using SignalRExample.Dto.ProductDto;
using SignalRExample.Entity.Entities;

namespace SignalRExample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<ICollection<ResultProductDto>>(await _productService.GetAllAsync()));
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<GetProductDto>(await _productService.GetByIdAsync(id)));
        }

        [HttpGet]
        public async Task<IActionResult> ProductListWithCategory()
        {
            return Ok(_mapper.Map<ICollection<ResultProductWithCategory>>(await _productService.GetProductsWithCategoriesAsync()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            await _productService.CreateAsync(_mapper.Map<Product>(createProductDto));
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _productService.GetByIdAsync(id);
            await _productService.DeleteAsync(value);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(updateProductDto));
            return Ok();
        }
    }
}
