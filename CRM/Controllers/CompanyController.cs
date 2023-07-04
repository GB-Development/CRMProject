using AutoMapper;
using CRM.Data;
using CRM.Model.DTO;
using CRM.Model.Entities;
using CRM.Services.Interfaces;
using CRM.Services.Repositories;
using CRM.Services.Repositories.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.Controllers
{
    [Route("api/company")]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _dbContext;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Company>>> GetAll()
        {
            var result = await _dbContext.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CompanyCreateDto item)
        {
            var company = _mapper.Map<Company>(item);

            if (company == null)
                return NotFound();

            await _dbContext.CreateAsync(company);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CompanyUpdateDto item)
        {
            var company = _mapper.Map<Company>(item);

            if (company == null)
                return NotFound();

            await _dbContext.UpdateAsync(company);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] CompanyDeleteDto item)
        {
            var company = _mapper.Map<Company>(item);

            if (company == null)
                return NotFound();

            await _dbContext.DeleteAsync(company);
            return Ok();
        }

        [HttpGet("GetByID")]
        public async Task<ActionResult<Company>> GetByID(int id)
        {
            var company = await _dbContext.GetByIDAsync(id);

            if (company == null)
                return NotFound();

            return Ok(company);
        }
    }
}