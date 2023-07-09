using CRM.Data;
using CRM.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.Services.Repositories.Implementation
{
	public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(Contact item)
        {
            if (_dbContext.Companies.FirstOrDefault(x => x.CompanyId == item.CompanyId) == null)
            {
                return 0;
            }
            var result = await _dbContext.Contacts.AddAsync(item);

            await _dbContext.SaveChangesAsync();

            return result.Entity.ContactId;
        }

        public async Task<bool> DeleteAsync(Contact item)
        {
            var contact = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.ContactId == item.ContactId);

            if (contact == null)
                return false;

            _dbContext.Contacts.Remove(contact);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(Contact item)
        {
            var contact = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.ContactId == item.ContactId && x.CompanyId == item.CompanyId);

            if (contact == null)
                return false;

            //TODO: ...in extention
            contact.FullName = item.FullName;
		    contact.PhoneNumber = item.PhoneNumber;
		    contact.Email = item.Email;
		    contact.Address = item.Address;

		    _dbContext.Contacts.Update(contact);

			var count = await _dbContext.SaveChangesAsync();

			return count > 0 ? true : false;
		}

        public async Task<bool> CreateCollectionAsync(List<Contact> items)
        {
            await _dbContext.AddRangeAsync(items);

			var result = await _dbContext.SaveChangesAsync();

			return result == items.Count ? true : false;
		}

		public async Task<List<Contact>> GetAllAsync()
		{
			return await _dbContext.Contacts.ToListAsync();
		}

		public async Task<Contact?> GetByIDAsync(int id)
		{
			var contact = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.ContactId == id);

			return contact;
		}
	}
}
