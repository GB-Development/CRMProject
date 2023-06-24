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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Create(Contact item)
        {

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

        public bool Delete(Contact item)
        {
            throw new NotImplementedException();
        }

        public Contact Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAll()
        {
            throw new NotImplementedException();
        }

        public Contact Update(Contact item)
        {
            throw new NotImplementedException();
        }
    }
}
