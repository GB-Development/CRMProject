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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Create(Deal item)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        public async Task CreateCollection(List<Deal> items)
        {
            _dbContext.AddRange(items);
            await _dbContext.SaveChangesAsync();
        }
    }
}
