using CRM.Data;
using CRM.Model.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;

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
        public void Create(Deal item)
        {

        }
        /// <summary>
        /// Представляет реализацию метода создания и сохранения коллекции объектов типа <see cref="Deal"/> в БД
        /// </summary>
        /// <param name="items"></param>
        public async Task CreateCollection(List<Deal> items)
        {
            _dbContext.AddRange(items);
            await _dbContext.SaveChangesAsync();
        }


        /// <summary>
        /// Представляет реализацию метода чтения коллекции объектов типа <see cref="Deal"/> в БД
        /// </summary>
        /// <param name="items"></param>
        public List<Deal> ReadCollection()
        {
            return _dbContext.Deals.ToList();
            //не пойму ни как что правильнее return _dbContext.Find<List<Deal>>(); и вообще совсем не то!
        }

    }
}
