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
        public async Task CreateCollectionAsync(List<Deal> items)
        {
            _dbContext.AddRange(items);
            await _dbContext.SaveChangesAsync();
        }

        public bool Delete(Deal item)
        {
            throw new NotImplementedException();
        }

        public Deal Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Deal> GetAll()
        {
            throw new NotImplementedException();
        }

        public Deal Update(Deal item)
        {
            throw new NotImplementedException();
        }
    }
}
