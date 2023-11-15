using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRExample.Business.Abstract;
using SignalRExample.Dto.DiscountDto;
using SignalRExample.Entity.Entities;

namespace SignalRExample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<ICollection<ResultDiscountDto>>(await _discountService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<GetDiscountDto>(await _discountService.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDiscountDto createDiscountDto)
        {
            await _discountService.CreateAsync(_mapper.Map<Discount>(createDiscountDto));
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _discountService.GetByIdAsync(id);
            await _discountService.DeleteAsync(value);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDiscountDto updateDiscountDto)
        {
            await _discountService.UpdateAsync(_mapper.Map<Discount>(updateDiscountDto));
            return Ok();
        }
    }
}
