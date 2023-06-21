using CRM.Data;
using CRM.Model.Entities;

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

        public void CreateCollection(List<Deal> items)
        {
            throw new NotImplementedException();
        }
    }
}
