using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRExample.Business.Abstract;
using SignalRExample.Dto.CategoryDto;
using SignalRExample.Entity.Entities;

namespace SignalRExample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<ICollection<ResultCategoryDto>>(await _categoryService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<GetCategoryDto>(await _categoryService.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateAsync(_mapper.Map<Category>(createCategoryDto));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _categoryService.GetByIdAsync(id);
            await _categoryService.DeleteAsync(value);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateAsync(_mapper.Map<Category>(updateCategoryDto));
            return Ok();
        }
    }
}
