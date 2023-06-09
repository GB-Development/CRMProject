﻿using AutoMapper;
using CRM.Model.DTO;
using CRM.Model.Entities;
using CRM.Services.Repositories;
using CRM.Services.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
	[Route("api/[controller]")]
    public class DealController : Controller
    {
        private readonly IDealRepository _dealRepository;
        private readonly IMapper _mapper;

        public DealController(IDealRepository dealRepository,
            IMapper mapper)
        {
            _dealRepository = dealRepository;
            _mapper = mapper;
        }

		[HttpPost("СreateDeal"),
		ProducesResponseType(typeof(int),
		StatusCodes.Status200OK)]
		public async Task<ActionResult<int>> CreateDealAsync([FromBody] DealCreateDto item)
		{
			if (!ModelState.IsValid)
				return Ok(0);

			var contact = _mapper.Map<Deal>(item);
			if (contact == null)
				return Ok(0);

			var result = await _dealRepository.CreateAsync(contact);

			return Ok(result);
		}

		[HttpGet("GetAllDeals"),
		ProducesResponseType(typeof(List<Deal>),
		StatusCodes.Status200OK)]
		public async Task<ActionResult<List<Deal>>> GetAllDealAsync()
		{
			var result = await _dealRepository.GetAllAsync();

			return Ok(result);
		}

		[HttpPut("UpdateDeal"),
		ProducesResponseType(typeof(bool),
		StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> UpdateDealAsync([FromBody] DealUpdateDto item)
		{
			if (!ModelState.IsValid)
				return Ok(false);

			var contact = _mapper.Map<Deal>(item);

			if (contact == null)
				return Ok(false);

			var result = await _dealRepository.UpdateAsync(contact);

			return Ok(result);
		}

		[HttpDelete("DeleteDeal"),
		ProducesResponseType(typeof(bool),
		StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> DeleteDealAsync([FromBody] DealDeleteDto item)
		{
			if (!ModelState.IsValid)
				return Ok(false);

			var contact = _mapper.Map<Deal>(item);

			if (contact == null)
				return Ok(false);

			var result = await _dealRepository.DeleteAsync(contact);

			return Ok(result);
		}

		[HttpGet("GetDealByID"),
		ProducesResponseType(typeof(Deal),
		StatusCodes.Status200OK)]
		public async Task<ActionResult<Deal>> GetDealByIDAsync(int id)
		{
			var contact = await _dealRepository.GetByIDAsync(id);

			return Ok(contact);
		}

        [HttpGet("GetDealByIDManager"),
		ProducesResponseType(typeof(List<Deal>),
		StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Deal>>> GetAllDealsByIDManagerAsync(string id)
        {
            var deal = await _dealRepository.GetAllByIdManagerAsync(id);

            return Ok(deal);
        }
    }
}