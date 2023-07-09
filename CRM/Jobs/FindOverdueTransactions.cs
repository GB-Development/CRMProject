using CRM.Model.Entities;
using CRM.Services.Repositories;

namespace CRM.Jobs
{
    public class FindOverdueTransactions : IFindOverdueTransactionsJobs
    {

        private readonly IDealRepository _dealRepository;
        private readonly IDealRepository _dealRepository1;
        public FindOverdueTransactions(IDealRepository dealRepository)
        {
            _dealRepository = dealRepository;
        }

        public async Task<List<Deal>> FindTransaction()
        {
            List<Deal> list = await _dealRepository.ReadCollectionAsync();
            var listNotification = list.Where(x => x.DateContact < DateTime.Now).ToList();
            return listNotification;
        }
    }
}
