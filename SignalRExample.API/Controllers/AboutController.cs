using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRExample.Business.Abstract;
using SignalRExample.Dto.AboutDto;
using SignalRExample.Entity.Entities;

namespace SignalRExample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<ICollection<ResultAboutDto>>(await _aboutService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<GetAboutDto>(await _aboutService.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAsync(_mapper.Map<About>(createAboutDto));
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _aboutService.GetByIdAsync(id);
            await _aboutService.DeleteAsync(value);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAsync(_mapper.Map<About>(updateAboutDto));
            return Ok();
        }
    }
}
