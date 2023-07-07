using CRM.Data;
using CRM.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.Services.Repositories.Implementation
{
	public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Company item)
        {
            var result = await _dbContext.Companies.AddAsync(item);

            await _dbContext.SaveChangesAsync();

            return result.Entity.CompanyId;
        }

        public async Task<bool> DeleteAsync(Company item)
        {
            var a = await _dbContext.Companies.FirstOrDefaultAsync(x => x.CompanyId == item.CompanyId);

            if (a == null)
                return false;

            _dbContext.Companies.Remove(a);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Company?> GetByIDAsync(int id)
        {
            var a = await _dbContext.Companies.Include(y => y.Contacts).FirstOrDefaultAsync(x => x.CompanyId == id);
            return a;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _dbContext.Companies.Include(x => x.Contacts).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Company item)
        {
            var a = await _dbContext.Companies.FirstOrDefaultAsync(x => x.CompanyId == item.CompanyId);

            if (a == null)
                return false;

            a.INN = item.INN;
            a.CompanyName = item.CompanyName;

            _dbContext.Companies.Update(a);

            var count = await _dbContext.SaveChangesAsync();

            return count > 0 ? true : false;
        }
        public async Task<bool> CreateCollectionAsync(List<Company> items)
        {
            await _dbContext.AddRangeAsync(items);
            var result = await _dbContext.SaveChangesAsync();

            return result == items.Count ? true : false;
        }
	}
}
