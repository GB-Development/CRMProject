using CRM.Data;
using CRM.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.Services.Repositories.Implementation
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ContactRepository"/>
        /// </summary>
        /// <param name="dbContext"></param>
        public ContactRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Представляет реализацию метода создания и сохранения одиночного объекта типа <see cref="Contact"/> в БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Возращает ID сущности в БД</returns>
        public async Task<int> CreateAsync(Contact item)
        {
            var entity = _dbContext.Contacts.Add(item);

            await _dbContext.SaveChangesAsync();

            return entity.Entity.ContactId;
        }

        /// <summary>
        /// Представляет реализацию метода создания и сохранения коллекции объектов типа <see cref="Contact"/> в БД
        /// </summary>
        /// <param name="items"></param>
        public async Task CreateCollectionAsync(List<Contact> items)
        {
            _dbContext.AddRange(items);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Представляет реализацию метода удаления одиночного объекта типа <see cref="Contact"/> в БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Возращает статус выполнение метода типа bool</returns>
        public async Task<bool> DeleteAsync(Contact item)
        {
            Contact contact = await GetByIdAsync(item.ContactId);

            if (contact != null)
            {
                _dbContext.Contacts.Remove(contact);
                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Представляет реализацию метода получение коллекции объектов типа <see cref="Contact"/> из БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Возращает сущности из БД </returns>
        public async Task<List<Contact>> GetAllAsync()
        {
            return await _dbContext.Contacts.ToListAsync();
        }

        /// <summary>
        /// Представляет реализацию метода получение одиночного объекта типа <see cref="Contact"/> из БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Возращает сущность из БД типа <see cref="Contact"/></returns>
        public async Task<Contact?> GetByIdAsync(int id)
        {
            return await _dbContext.Contacts.FirstOrDefaultAsync(x => x.ContactId == id);
        }

        /// <summary>
        /// Представляет реализацию метода обновление одиночного объекта типа <see cref="Contact"/> в БД
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Возращает статус выполнение метода типа bool</returns>
        public async Task<bool> UpdateAsync(Contact item)
        {
            if (item != null)
            {
                _dbContext.Contacts.Update(item);

                var result = await _dbContext.SaveChangesAsync();

                return result > 0 ? true : false;
            }

            return false;
        }
    }
}
