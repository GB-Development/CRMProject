using CRM.Data;
using CRM.Data.Entities;

namespace CRM.Services.Repositories.Implementation
{
    public class DealRepository : IDealRepository
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public DealRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> CreateAsync(Deal item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        public async Task CreateCollectionAsync(List<Deal> items)
        {
            _dbContext.AddRange(items);
            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> DeleteAsync(Deal item)
        {
            throw new NotImplementedException();
        }

        public Task<List<Deal>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Deal?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Deal item)
        {
            throw new NotImplementedException();
        }
    }
}
