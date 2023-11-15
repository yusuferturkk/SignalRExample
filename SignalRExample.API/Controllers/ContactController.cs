using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRExample.Business.Abstract;
using SignalRExample.Dto.ContactDto;
using SignalRExample.Entity.Entities;

namespace SignalRExample.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<ICollection<ResultContactDto>>(await _contactService.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<GetContactDto>(await _contactService.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto createContactDto)
        {
            await _contactService.CreateAsync(_mapper.Map<Contact>(createContactDto));
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await _contactService.GetByIdAsync(id);
            await _contactService.DeleteAsync(value);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactDto updateContactDto)
        {
            await _contactService.UpdateAsync(_mapper.Map<Contact>(updateContactDto));
            return Ok();
        }
    }
}
