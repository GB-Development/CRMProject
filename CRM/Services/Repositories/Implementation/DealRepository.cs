using CRM.Data;
using CRM.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.Services.Repositories.Implementation
{
    public class DealRepository : IDealRepository
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DealRepository"/>
        /// </summary>
        /// <param name="dbContext"></param>
        public DealRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Представляет реализацию метода создания и сохранения одиночного объекта типа <see cref="Deal"/> в БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Возращает ID сущности в БД</returns>
        public async Task<int> CreateAsync(Deal item)
        {
            var entity = _dbContext.Deals.Add(item);

            await _dbContext.SaveChangesAsync();

            return entity.Entity.DealId;
        }

        /// <summary>
        /// Представляет реализацию метода создания и сохранения коллекции объектов типа <see cref="Deal"/> в БД
        /// </summary>
        /// <param name="items"></param>
        public async Task CreateCollectionAsync(List<Deal> items)
        {
            _dbContext.AddRange(items);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Представляет реализацию метода удаления одиночного объекта типа <see cref="Deal"/> в БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Возращает статус выполнение метода типа bool</returns>
        public async Task<bool> DeleteAsync(Deal item)
        {
            Deal deal = await GetByIdAsync(item.DealId);

            if (deal != null)
            {
                _dbContext.Deals.Remove(deal);
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Представляет реализацию метода получение коллекции объектов типа <see cref="Deal"/> из БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Возращает сущности из БД </returns>
        public async Task<List<Deal>> GetAllAsync()
        {
            return await _dbContext.Deals.ToListAsync();
        }

        /// <summary>
        /// Представляет реализацию метода получение одиночного объекта типа <see cref="Deal"/> из БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Возращает сущность из БД типа <see cref="Deal"/></returns>
        public async Task<Deal?> GetByIdAsync(int id)
        {
            return await _dbContext.Deals.FirstOrDefaultAsync(x => x.DealId == id);
        }

        /// <summary>
        /// Представляет реализацию метода обновление одиночного объекта типа <see cref="Deal"/> в БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Возращает статус выполнение метода типа bool</returns>
        public async Task<bool> UpdateAsync(Deal item)
        {
            if (item != null)
            {
                _dbContext.Deals.Update(item);

                var result = await _dbContext.SaveChangesAsync();

                return result > 0 ? true : false;
            }

            return false;
        }
    }
}
