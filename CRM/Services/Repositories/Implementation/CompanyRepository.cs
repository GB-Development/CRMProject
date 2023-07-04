using AutoMapper;
using CRM.Controllers;
using CRM.Data;
using CRM.Model.DTO;
using CRM.Model.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CRM.Services.Repositories.Implementation
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CompanyRepository(ApplicationDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateAsync(Company item)
        {
            await _dbContext.Companies.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Company item)
        {
            var a = await _dbContext.Companies.FirstOrDefaultAsync(x => x.CompanyId == item.CompanyId);

            if (a == null)
                return;

            _dbContext.Companies.Remove(a);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Company?> GetByIDAsync(int id)
        {
            var a = await _dbContext.Companies.Include(y => y.Contacts).FirstOrDefaultAsync(x => x.CompanyId == id);
            return a;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _dbContext.Companies.Include(y => y.Contacts).ToListAsync();
        }

        public async Task UpdateAsync(Company item)
        {
            var a = await _dbContext.Companies.FirstOrDefaultAsync(x => x.CompanyId == item.CompanyId);

            if (a == null)
                return;

            a.INN = item.INN;
            a.CompanyName = item.CompanyName;

            _dbContext.Companies.Update(a);
            var count = await _dbContext.SaveChangesAsync();
            await Console.Out.WriteLineAsync(count.ToString());
        }
        public async Task CreateCollection(List<Company> items)
        {
            _dbContext.AddRange(items);
            await _dbContext.SaveChangesAsync();
        }
    }
}
