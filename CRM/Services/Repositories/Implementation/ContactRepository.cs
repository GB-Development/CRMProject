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
        public async Task CreateCollection(List<Contact> items)
        {
            _dbContext.AddRange(items);
            await _dbContext.SaveChangesAsync();
        }
    }
}
