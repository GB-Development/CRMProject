using CRM.Data;
using CRM.Data.Entities;

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
        public int Create(Company item)
        {
            throw new NotImplementedException();
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

        public bool Delete(Company item)
        {
            throw new NotImplementedException();
        }

        public Company Get(int id)
        {
            return new Company { CompanyId = id };
        }

        public List<Company> GetAll()
        {
            throw new NotImplementedException();
        }

        public Company Update(Company item)
        {
            throw new NotImplementedException();
        }
    }
}
