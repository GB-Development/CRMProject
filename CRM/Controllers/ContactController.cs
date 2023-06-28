using AutoMapper;
using CRM.Data;
using CRM.Model.DTO;
using CRM.Model.Entities;
using CRM.Services.Interfaces;
using CRM.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.Controllers
{
    [Route("api/contact")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _dbContext;
        private readonly IMapper _mapper;

        public ContactController(IContactRepository dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ContactCreateDto item)
        {
            var contact = _mapper.Map<Contact>(item);

            if (contact == null)
                return NotFound();

            await _dbContext.CreateAsync(contact);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ContactUpdateDto item)
        {
            var contact = _mapper.Map<Contact>(item);

            if (contact == null)
                return NotFound();

            await _dbContext.UpdateAsync(contact);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] ContactDeleteDto item)
        {
            var contact = _mapper.Map<Contact>(item);

            if (contact == null)
                return NotFound();

            await _dbContext.DeleteAsync(contact);
            return Ok();
        }

    }
}