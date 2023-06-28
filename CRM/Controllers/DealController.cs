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
    [Route("api/deal")]
    public class DealController : Controller
    {
        private readonly IDealRepository _dbContext;
        private readonly IMapper _mapper;

        public DealController(IDealRepository dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] DealCreateDto item)
        {
            var deal = _mapper.Map<Deal>(item);

            if (deal == null)
                return NotFound();

            var company = _mapper.Map<Company>(item.Company);

            deal.Company = company;

            await _dbContext.CreateAsync(deal);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] DealUpdateDto item)
        {
            var deal = _mapper.Map<Deal>(item);

            if (deal == null)
                return NotFound();

            var company = _mapper.Map<Company>(item.Company);

            deal.Company = company;

            await _dbContext.UpdateAsync(deal);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DealDeleteDto item)
        {
            var deal = _mapper.Map<Deal>(item);

            if (deal == null)
                return NotFound();

            await _dbContext.CreateAsync(deal);
            return Ok();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _dbContext.GetAllAsync());
        }

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetByID(int id)
        {
            var deal = await _dbContext.GetByIdAsync(id);

            if (deal == null)
                return NotFound();

            return Ok(deal);
        }

        [HttpGet("GetByIDManager")]
        public async Task<IActionResult> GetAllByIDManagerAsync(string id)
        {
            var deal = await _dbContext.GetAllByIdManagerAsync(id);

            if (deal == null)
                return NotFound();

            return Ok(deal);
        }
    }
}