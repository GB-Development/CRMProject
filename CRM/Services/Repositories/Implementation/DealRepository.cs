using CRM.Data;
using CRM.Model.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CRM.Services.Repositories.Implementation
{
    /// <summary>
    /// Представляет реализацию репозитория для работы с объектами типа  <see cref="Deal"/>
    /// </summary>
    public class DealRepository : IDealRepository<Deal>

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
        public void CreateCollection(List<Deal> items)
        {
            _dbContext.AddRange(items);
            _dbContext.SaveChanges();
        }
        /// <summary>
        /// Представляет реализацию метода чтения коллекции объектов типа <see cref="Deal"/> в БД
        /// </summary>
        /// <param name="items"></param>
        public List<Deal> ReadCollection()
        {
            return _dbContext.GetService<List<Deal>>().ToList();
            //не пойму ни как что правильнее return _dbContext.Find<List<Deal>>(); и вообще совсем не то!
        }

    }
}
