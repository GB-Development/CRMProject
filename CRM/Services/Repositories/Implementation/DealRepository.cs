using CRM.Data;
using CRM.Model.Entities;
using Microsoft.EntityFrameworkCore;


namespace CRM.Services.Repositories.Implementation
{
	/// <summary>
	/// Представляет реализацию репозитория для работы с объектами типа  <see cref="Deal"/>
	/// </summary>
	public class DealRepository : IDealRepository

    {
        private readonly ApplicationDbContext _dbContext;


        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DealRepository"/>
        /// </summary>

        public DealRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Представляет реализацию метода создания и сохранения одиночного объекта типа <see cref="Deal"/> в БД
        /// </summary>
        /// <param name="item"></param>
        public void Create(Deal item) { }


        public async Task<int> CreateAsync(Deal item)
        {
            item.DateCreate = DateTime.Now;

            var result = await _dbContext.Deals.AddAsync(item);

            await _dbContext.SaveChangesAsync();

            return result.Entity.DealId;
        }

        public async Task<bool> DeleteAsync(Deal item)
        {
            var deal = await _dbContext.Deals.FirstOrDefaultAsync(x => x.DealId == item.DealId);

            if (deal == null)
                return false;

            _dbContext.Deals.Remove(item);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(Deal item)
        {
            var deal = await _dbContext.Deals.FirstOrDefaultAsync(x => x.DealId == item.DealId);

            if (deal == null)
                return false;

            deal.ManagerId = item.ManagerId;
            deal.CompanyId = item.CompanyId;
            deal.Company = await _dbContext.Companies.FirstOrDefaultAsync(c => c.CompanyId == item.CompanyId);
            deal.DateContact = item.DateContact;

            _dbContext.Deals.Update(item);

			var count = await _dbContext.SaveChangesAsync();

			return count > 0 ? true : false;
		}

        public async Task<List<Deal>> GetAllAsync()
        {
            return await _dbContext.Deals
                .Include(y => y.Company)
                .ThenInclude(x => x.Contacts)
                .ToListAsync();
        }

        public async Task<Deal?> GetByIDAsync(int id)
        {
            var deal = await _dbContext.Deals
                .Include(y => y.Company)
                .ThenInclude(x => x.Contacts)
                .FirstOrDefaultAsync(x => x.DealId == id);

            return deal;
        }

        public async Task<List<Deal>> GetAllByIdManagerAsync(string id)
        {
            var deals = await _dbContext.Deals
                .Include(y => y.Company)
                .ThenInclude(x => x.Contacts)
                .Where(x => x.ManagerId == id)
                .ToListAsync();

            return deals;
        }
        public async Task<bool> CreateCollectionAsync(List<Deal> items)
        {
            await _dbContext.AddRangeAsync(items);

			var result = await _dbContext.SaveChangesAsync();

			return result == items.Count ? true : false;
		}


        /// <summary>
        /// Представляет реализацию метода чтения коллекции объектов типа <see cref="Deal"/> в БД
        /// </summary>
        /// <param name="items"></param>
        public async Task<List<Deal>> ReadCollectionAsync()
        {
            return await _dbContext.Deals
                .Include(x => x.Company)
                .ThenInclude(x => x.Contacts)
                .ToListAsync();
        }
	}
}
