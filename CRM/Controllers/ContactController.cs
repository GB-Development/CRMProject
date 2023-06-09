﻿using AutoMapper;
using CRM.Model.DTO;
using CRM.Model.Entities;
using CRM.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
	[Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactController(IContactRepository contactRepository,
            IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

		[HttpPost("СreateContact"),
		ProducesResponseType(typeof(int),
		StatusCodes.Status200OK)]
		public async Task<ActionResult<int>> CreateContactAsync([FromBody] ContactCreateDto item)
        {
			if (!ModelState.IsValid)
				return Ok(0);

			var contact = _mapper.Map<Contact>(item);

			if (contact == null)
				return Ok(0);

			var result = await _contactRepository.CreateAsync(contact);

            return Ok(result);
        }

		[HttpGet("GetAllContacts"),
		ProducesResponseType(typeof(List<Contact>),
		StatusCodes.Status200OK)]
		public async Task<ActionResult<List<Contact>>> GetAllContactAsync()
		{
			var result = await _contactRepository.GetAllAsync();

			return Ok(result);
		}

		[HttpPut("UpdateContact"),
		ProducesResponseType(typeof(bool),
		StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> UpdateContactAsync([FromBody] ContactUpdateDto item)
		{
			if (!ModelState.IsValid)
				return Ok(false);

			var contact = _mapper.Map<Contact>(item);

			if (contact == null)
				return Ok(false);

			var result = await _contactRepository.UpdateAsync(contact);

			return Ok(result);
		}

		[HttpDelete("DeleteContact"),
		ProducesResponseType(typeof(bool),
		StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> DeleteContactAsync([FromBody] ContactDeleteDto item)
		{
			if (!ModelState.IsValid)
				return Ok(false);

			var contact = _mapper.Map<Contact>(item);

			if (contact == null)
				return Ok(false);

			var result = await _contactRepository.DeleteAsync(contact);

			return Ok(result);
		}

		[HttpGet("GetContactByID"),
		ProducesResponseType(typeof(Contact),StatusCodes.Status200OK)]
		public async Task<ActionResult<Contact?>> GetContactByIDAsync(int id)
		{
			var contact = await _contactRepository.GetByIDAsync(id);

			return Ok(contact);
		}

	}
}