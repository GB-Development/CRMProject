﻿using AutoMapper;
using CRM.Model.DTO;
using CRM.Model.Entities;
using CRM.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
	[Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepository,
            IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll"),
		ProducesResponseType(typeof(ActionResult<List<Company>>),
		StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Company>>> GetAllComponiesAsync()
        {
            var result = await _companyRepository.GetAllAsync();

            return Ok(result);
        }

		[HttpPost("Сreate"),
		ProducesResponseType(typeof(ActionResult<int>),
		StatusCodes.Status200OK)]
		public async Task<ActionResult<int>> CreateCompanyAsync([FromBody] CompanyCreateDto item)
        {
            if (!ModelState.IsValid)
                return Ok(0);

            var company = _mapper.Map<Company>(item);

            if (company == null)
                return Ok(0);

            var result = await _companyRepository.CreateAsync(company);

            return Ok(result);
        }

        [HttpPut("Update"),
		ProducesResponseType(typeof(ActionResult<bool>),
		StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> UpdateCompanyAsync([FromBody] CompanyUpdateDto item)
        {
			if (!ModelState.IsValid)
				return Ok(false);

			var company = _mapper.Map<Company>(item);

            if (company == null)
                return Ok(false);

            var result = await _companyRepository.UpdateAsync(company);

            return Ok(result);
        }

        [HttpDelete("Delete"),
		ProducesResponseType(typeof(ActionResult<bool>),
		StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> DeleteCompanyAsync([FromBody] CompanyDeleteDto item)
        {
			if (!ModelState.IsValid)
				return Ok(false);

			var company = _mapper.Map<Company>(item);

            if (company == null)
                return Ok(false);

            var result = await _companyRepository.DeleteAsync(company);

            return Ok(result);
        }

        [HttpGet("GetByID"),
		ProducesResponseType(typeof(ActionResult<Company>),
		StatusCodes.Status200OK)]
        public async Task<ActionResult<Company>> GetCompanyByIDAsync(int id)
        {
            var company = await _companyRepository.GetByIDAsync(id);

            return Ok(company);
        }
    }
}