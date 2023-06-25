using CRM.Data;
using CRM.Data.Entities;

namespace CRM.Services.Repositories.Implementation
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public ContactRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> CreateAsync(Contact item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        public async Task CreateCollectionAsync(List<Contact> items)
        {
            _dbContext.AddRange(items);
            await _dbContext.SaveChangesAsync();
        }

        public Task<bool> DeleteAsync(Contact item)
        {
            throw new NotImplementedException();
        }

        public Task<List<Contact>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Contact?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Contact item)
        {
            throw new NotImplementedException();
        }
    }
}
