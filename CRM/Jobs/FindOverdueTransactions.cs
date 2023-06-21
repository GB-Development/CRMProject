using CRM.Data;
using CRM.Model.Entities;
using CRM.Services.Repositories.Implementation;

namespace CRM.Jobs
{
    public class FindOverdueTransactions : IFindOverdueTransactionsJobs
    {
        private readonly ApplicationDbContext _dbContext;
        public FindOverdueTransactions() 
        { 

        }

        public void FindOverdueTransaction()
        {
            var items = new List<Deal>();
            var repo = new DealRepository(_dbContext);
            repo.ReadCollection(items);
            
        }
    }
}
