using CRM.Model.Entities;

namespace CRM.Jobs
{
    public interface IFindOverdueTransactionsJobs
    {
        Task<List<Deal>> FindTransaction();
    }
}
