using CRM.Data;
using CRM.Migrations;
using CRM.Model.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CRM.Services.Repositories.Implementation
{
    public class DealRepository : IDealRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public DealRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Deal item)
        {
            if (item.Company == null)
                return;

            var company = await _dbContext.Companies.FirstOrDefaultAsync(x => x.INN == item.Company.INN);

            if (company == null)
            {
                _dbContext.Companies.Add(item.Company);
                _dbContext.SaveChanges();
            }

            company = await _dbContext.Companies.FirstOrDefaultAsync(x => x.INN == item.Company.INN);

            if (company == null)
                return;
            
            item.DateCreate = DateTime.Now;
            await _dbContext.Deals.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Deal item)
        {
            var deal = await _dbContext.Deals.FirstOrDefaultAsync(x => x.DealId == item.DealId);

            if (deal == null)
                return;

            _dbContext.Deals.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Deal item)
        {
            var deal = await _dbContext.Deals.FirstOrDefaultAsync(x => x.DealId == item.DealId);

            if (deal == null)
                return;

            if (item.Company == null)
                return;

            var company = await _dbContext.Companies.FirstOrDefaultAsync(x => x.INN == item.Company.INN);

            if (company == null)
            {
                _dbContext.Companies.Add(item.Company);
                _dbContext.SaveChanges();
            }

            company = _dbContext.Companies.FirstOrDefault(x => x.INN == item.Company.INN);

            if (company == null)
                return;

            _dbContext.Deals.Update(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Deal>> GetAllAsync()
        {
            return await _dbContext.Deals.Include(y => y.Company).Include(x => x.Company.Contacts).ToListAsync();
        }

        public async Task<Deal> GetByIdAsync(int id)
        {
            var deal = await _dbContext.Deals.Include(y => y.Company).Include(x => x.Company.Contacts).FirstOrDefaultAsync(x => x.DealId == id);
            return deal;
        }

        public async Task<List<Deal>> GetAllByIdManagerAsync(string id)
        {
            var deals = await _dbContext.Deals.Include(y => y.Company).Include(x => x.Company.Contacts).Where(x => x.ManagerId == id).ToListAsync();
            return deals;
        }

        public async Task CreateCollection(List<Deal> items)
        {
            _dbContext.AddRange(items);
            await _dbContext.SaveChangesAsync();
        }
    }
}
