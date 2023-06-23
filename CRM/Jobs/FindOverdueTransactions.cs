using CRM.Model.Entities;
using CRM.Services.Repositories;

namespace CRM.Jobs
{
    public class FindOverdueTransactions : IFindOverdueTransactionsJobs
    {

        private readonly IDealRepository<Deal> _dealRepository;
        public FindOverdueTransactions(IDealRepository<Deal> dealRepository)
        {
            _dealRepository = dealRepository;
        }

        public List<Deal> FindTransaction<T>()
        {
            List<Deal> list = _dealRepository.ReadCollection();
            var listNotification = list.Where(x => x.DateContact > DateTime.Now).ToList();
            return listNotification;
        }
    }
}
