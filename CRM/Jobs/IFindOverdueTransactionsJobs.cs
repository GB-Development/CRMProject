using CRM.Model.Entities;

namespace CRM.Jobs
{
    public interface IFindOverdueTransactionsJobs
    {
        List<Deal> FindTransaction<T>();
    }
}
