using AutoMapper;
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

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Company>>> GetAll()
        {
            var result = await _companyRepository.GetAllAsync();
            return Ok(result);
        }

		[HttpPost("Сreate"),
		ProducesResponseType(typeof(ActionResult<string>),
		StatusCodes.Status200OK)]
		public async Task<ActionResult<string>> Create([FromBody] CompanyCreateDto item)
        {
            var company = _mapper.Map<Company>(item);

            if (company == null)
                return Ok("NULL");

            var result = await _companyRepository.CreateAsync(company);

            return Ok(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CompanyUpdateDto item)
        {
            var company = _mapper.Map<Company>(item);

            if (company == null)
                return NotFound();

            await _companyRepository.UpdateAsync(company);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] CompanyDeleteDto item)
        {
            var company = _mapper.Map<Company>(item);

            if (company == null)
                return NotFound();

            await _companyRepository.DeleteAsync(company);
            return Ok();
        }

        [HttpGet("GetByID")]
        public async Task<ActionResult<Company>> GetByID(int id)
        {
            var company = await _companyRepository.GetByIDAsync(id);

            if (company == null)
                return NotFound();

            return Ok(company);
        }
    }
}