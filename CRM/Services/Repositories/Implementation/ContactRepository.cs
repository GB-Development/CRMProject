using CRM.Data;
using CRM.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace CRM.Services.Repositories.Implementation
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(Contact item)
        {
            await _dbContext.Contacts.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Contact item)
        {
            var contact = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.ContactId == item.ContactId && x.CompanyId == item.CompanyId);

            if (contact == null)
                return;

            _dbContext.Contacts.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contact item)
        {
            var contact = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.ContactId == item.ContactId && x.CompanyId == item.CompanyId);

            if (contact == null)
                return;

            _dbContext.Contacts.Update(item);
            await _dbContext.SaveChangesAsync();

        }

        public async Task CreateCollection(List<Contact> items)
        {
            _dbContext.AddRange(items);
            await _dbContext.SaveChangesAsync();
        }
    }
}
