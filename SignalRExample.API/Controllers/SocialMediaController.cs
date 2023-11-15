using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRExample.Business.Abstract;
using SignalRExample.Dto.SocialMediaDto;
using SignalRExample.Entity.Entities;

namespace SignalRExample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<ICollection<ResultSocialMediaDto>>(await _socialMediaService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<GetSocialMediaDto>(await _socialMediaService.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaDto createSocialMediaDto)
        {
            await _socialMediaService.CreateAsync(_mapper.Map<SocialMedia>(createSocialMediaDto));
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _socialMediaService.GetByIdAsync(id);
            await _socialMediaService.DeleteAsync(value);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSocialMediaDto updateSocialMediaDto)
        {
            await _socialMediaService.UpdateAsync(_mapper.Map<SocialMedia>(updateSocialMediaDto));
            return Ok();
        }
    }
}
