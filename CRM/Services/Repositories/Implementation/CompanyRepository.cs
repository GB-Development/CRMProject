using CRM.Data;
using CRM.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRM.Services.Repositories.Implementation
{
    /// <summary>
    /// Представляет реализацию репозитория для работы с объектами типа  <see cref="Company"/>
    /// </summary>
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CompanyRepository"/>
        /// </summary>
        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Представляет реализацию метода создания и сохранения одиночного объекта типа <see cref="Company"/> в БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Возращает ID сущности в БД</returns>
        public async Task<int> CreateAsync(Company item)
        {
            var entity = _dbContext.Companies.Add(item);

            await _dbContext.SaveChangesAsync();

            return entity.Entity.CompanyId;
        }

        /// <summary>
        /// Представляет реализацию метода создания и сохранения коллекции объектов типа <see cref="Company"/> в БД
        /// </summary>
        /// <param name="items"></param>
        public async Task CreateCollectionAsync(List<Company> items)
        {
            _dbContext.AddRange(items);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Представляет реализацию метода удаления одиночного объекта типа <see cref="Company"/> в БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Возращает статус выполнение метода типа bool</returns>
        public async Task<bool> DeleteAsync(Company item)
        {
            Company company = await GetByIdAsync(item.CompanyId);

            if (company != null)
            {
                _dbContext.Companies.Remove(company);
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Представляет реализацию метода получение одиночного объекта типа <see cref="Company"/> из БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Возращает сущность из БД типа <see cref="Company"/></returns>
        public async Task<Company?> GetByIdAsync(int id)
        {
            return await _dbContext.Companies.FirstOrDefaultAsync(x => x.CompanyId == id);
        }

        /// <summary>
        /// Представляет реализацию метода получение коллекции объектов типа <see cref="Company"/> из БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Возращает сущности из БД </returns>
        public async Task<List<Company>> GetAllAsync()
        {
            return await _dbContext.Companies.ToListAsync();
        }

        /// <summary>
        /// Представляет реализацию метода обновление одиночного объекта типа <see cref="Company"/> в БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Возращает статус выполнение метода типа bool</returns>
        public async Task<bool> UpdateAsync(Company item)
        {
            Company company = await GetByIdAsync(item.CompanyId);

            if (company != null)
            {
                company = item;

                var result = await _dbContext.SaveChangesAsync();

                return result > 0 ? true : false;
            }

            return false;
        }
    }
}
