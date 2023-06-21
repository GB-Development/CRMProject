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
            //В этом методе хочу прописать поиск просроченных сделок, 
            //для этого мне нужно обратиться к сущности сделки
            //и обратиться к CRM.Model.Entities.Deal -  DateContact
            //и сравнить с DateTime.Now
            //пока туплю и не могу понять как мне обратиться к DateContact
            var items = new List<Deal>();
            var repo = new DealRepository(_dbContext);
            repo.ReadCollection(items);
            
        }
    }
}
