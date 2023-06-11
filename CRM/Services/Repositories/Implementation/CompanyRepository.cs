using CRM.Data;
using CRM.Model.Entities;

namespace CRM.Services.Repositories.Implementation
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Create(Company item) { }

        public void CreateCollection(List<Company> items)
        {
            _dbContext.AddRange(items);
            _dbContext.SaveChanges();
        }
    }
}
